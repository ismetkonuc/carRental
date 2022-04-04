using AutoMapper;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Constants;
using CarRental.Business.Interfaces;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utils.Results;
using CarRental.DataAccess.Interfaces;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos.Car;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;

        public CarManager(ICarDal carDal, IMapper mapper)
        {
            _carDal = carDal;
            _mapper = mapper;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(CarInsertDto entity)
        {
            var convertedEntity = _mapper.Map<Car>(entity);
            _carDal.Add(convertedEntity);
            return new SuccessResult(true, Messages.EntityAdded);
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(CarUpdateDto entity)
        {
            var convertedEntity = _mapper.Map<Car>(entity);
            Car car = _carDal.Get(I => I.Id == convertedEntity.Id);

            if (car != null)
            {
                _carDal.Update(car);
                return new SuccessResult(true, Messages.EntityUpdated);
            }

            return new ErrorResult(false, Messages.EntityNotFound);

        }

        [SecuredOperation("Admin")]
        public IResult Delete(int id)
        {
            Car car = _carDal.Get(I => I.Id == id);

            if (car != null)
            {
                _carDal.Delete(car);
                return new SuccessResult(true, Messages.EntityDeleted);
            }

            return new ErrorResult(false, Messages.EntityNotFound);
        }

        public IDataResult<List<CarGetDto>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            var cars = _carDal.GetAll(filter);
            var convertedEntities = _mapper.Map<List<CarGetDto>>(cars);
            return new DataResult<List<CarGetDto>>(convertedEntities, true);
        }

        public IDataResult<CarGetDto> Get(Expression<Func<Car, bool>> filter)
        {
            var car = _carDal.Get(filter);
            var convertedEntity = _mapper.Map<CarGetDto>(car);
            return new DataResult<CarGetDto>(convertedEntity, true);
        }
    }
}