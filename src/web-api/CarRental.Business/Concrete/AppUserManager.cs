using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Business.Interfaces;
using CarRental.Core.Utils.Results;
using CarRental.Entities.Concrete;

namespace CarRental.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        public IResult Add(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public IResult Update(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<AppUser>> GetAll(Expression<Func<AppUser, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AppUser> Get(Expression<Func<AppUser, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}