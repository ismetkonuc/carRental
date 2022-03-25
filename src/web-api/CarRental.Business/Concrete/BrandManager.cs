using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Constants;
using CarRental.Business.Interfaces;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Caching;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utils.Business;
using CarRental.Core.Utils.Results;
using CarRental.DataAccess.Interfaces;
using CarRental.Entities.Concrete;

namespace CarRental.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand entity)
        {
            var rulesResult = BusinessRules.Run(CheckBrandPresence(entity.Name));

            if (rulesResult != null)
            {
                return rulesResult;
            }

            _brandDal.Add(entity);
            return new SuccessResult(true);
        }

        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand entity)
        {
            Brand brand = Get(I => I.Id == entity.Id).Data;

            if (brand != null)
            {
                _brandDal.Update(entity);
                return new SuccessResult(true, Messages.EntityUpdated);
            }

            return new ErrorResult(false, Messages.EntityNotFound);
        }

        public IResult Delete(Brand entity)
        {

            Brand brand = Get(I => I.Id == entity.Id).Data;

            if (brand != null)
            {
                _brandDal.Delete(entity);
                return new SuccessResult(true, Messages.EntityDeleted);
            }

            return new ErrorResult(false, Messages.EntityNotFound);
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {

            List<Brand> brands = _brandDal.GetAll(filter);

            IDataResult<List<Brand>> result = new SuccessDataResult<List<Brand>>(brands, true);

            return result;
        }

        [CacheAspect]
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(I => I.Id == brandId), true);
        }

        public IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter)
        {
            Brand brand = _brandDal.Get(filter);

            return new DataResult<Brand>(brand, true);
        }

        private IResult CheckBrandPresence(string brandName)
        {
            var isBrandExist = _brandDal.GetAll(I => I.Name == brandName).Any();

            if (!isBrandExist)
            {
                return new SuccessResult(true);
            }

            return new ErrorResult(false, Messages.BrandAlreadyExist);

        }
    }
}