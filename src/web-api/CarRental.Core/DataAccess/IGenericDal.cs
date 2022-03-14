using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Core.Entities;
using CarRental.Core.Utils.Results;

namespace CarRental.Core.DataAccess
{
    public interface IGenericDal<T> where T : class, IBaseEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = default);
        T Get(Expression<Func<T, bool>> filter);
    }
}