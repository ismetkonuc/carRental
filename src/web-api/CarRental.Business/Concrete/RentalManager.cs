using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Business.Interfaces;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utils.Results;
using CarRental.DataAccess.Interfaces;
using CarRental.Entities.Concrete;

namespace CarRental.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult(true);
        }

        public IResult Update(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}