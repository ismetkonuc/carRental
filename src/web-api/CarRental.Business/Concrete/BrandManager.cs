using AutoMapper;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Constants;
using CarRental.Business.Interfaces;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utils.Business;
using CarRental.Core.Utils.Results;
using CarRental.DataAccess.Interfaces;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;
        private readonly ICarService _carService;

        public BrandManager(IBrandDal brandDal, IMapper mapper, ICarService carService)
        {
            _brandDal = brandDal;
            _mapper = mapper;
            _carService = carService;

        }

        [ValidationAspect(typeof(BrandInsertValidator))]
        [SecuredOperation("Admin")]
        public IResult Add(BrandInsertDto entity)
        {
            Brand convertedEntity = _mapper.Map<Brand>(entity);
            var result = BusinessRules.Run(CheckBrandPresence(convertedEntity.Name));

            if (result != null)
            {
                _brandDal.Add(convertedEntity);
                return new SuccessResult(true, Messages.EntityAdded);
            }

            return new ErrorResult(false, Messages.EntityAlreadyExist);
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(BrandUpdateValidator))]
        public IResult Update(BrandUpdateDto entity)
        {
            Brand convertedEntity = _mapper.Map<Brand>(entity);
            var result = BusinessRules.Run(CheckBrandPresence(convertedEntity.Name));

            if (result != null)
            {
                _brandDal.Update(convertedEntity);
                return new SuccessResult(true, Messages.EntityUpdated);
            }

            return new ErrorResult(false, Messages.EntityAlreadyExist);
        }


        [SecuredOperation("Admin")]
        public IResult Delete(int id)
        {
            var entity = _brandDal.Get(I => I.Id == id);

            if (entity is not null)
            {
                _brandDal.Delete(entity);
                return new SuccessResult(true, Messages.EntityDeleted);
            }

            return new ErrorResult(false, Messages.EntityNotFound);
        }

        //[CacheAspect]
        public IDataResult<List<BrandGetDto>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {

            List<Brand> brands = _brandDal.GetAll(filter);

            List<BrandGetDto> convertedBrands = _mapper.Map<List<BrandGetDto>>(brands);

            SuccessDataResult<List<BrandGetDto>> result = new SuccessDataResult<List<BrandGetDto>>(convertedBrands, true);

            return result;
        }

        public IDataResult<BrandGetDto> Get(Expression<Func<Brand, bool>> filter)
        {
            var brand = _brandDal.Get(filter);
            BrandGetDto convertedBrand = _mapper.Map<BrandGetDto>(brand);

            if (convertedBrand != null)
            {
                convertedBrand.Cars = _carService.GetAll(I => I.BrandId == convertedBrand.Id).Data;
                return new DataResult<BrandGetDto>(convertedBrand, true);
            }

            return new DataResult<BrandGetDto>(null, true, Messages.EmptyBrand);
        }

        private IResult CheckBrandPresence(string brandName)
        {
            Brand brand = _brandDal.Get(I => I.Name.ToUpper().Equals(brandName.ToUpper()));

            if (brand != null)
            {
                return new Result(true);
            }

            return new Result(false, Messages.EntityNotFound);
        }


    }
}