using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Business.Interfaces;
using CarRental.Core.Utils.Results;
using CarRental.Entities.Concrete;

namespace CarRental.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        public IResult Add(Brand entity)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Brand entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}