using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Core.Entities;
using CarRental.Core.Utils.Results;

namespace CarRental.Business.Interfaces
{
    public interface IGenericService<T> where T : class, IBaseEntity, new()
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(int id);
        IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        IDataResult<T> Get(Expression<Func<T, bool>> filter);
    }
}