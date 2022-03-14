using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Business.Interfaces;
using CarRental.Core.Utils.Results;
using CarRental.Entities.Concrete;

namespace CarRental.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        public IResult Add(Rental entity)
        {
            throw new NotImplementedException();
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