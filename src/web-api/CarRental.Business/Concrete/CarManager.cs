using CarRental.Business.Interfaces;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utils.Business;
using CarRental.Core.Utils.Results;
using CarRental.DataAccess.Interfaces;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Business.BusinessAspects.Autofac;

namespace CarRental.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
            BusinessRules.Run();
            _carDal.Add(entity);
            return new SuccessResult(true);
        }

        public IResult Update(Car entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}