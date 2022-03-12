using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Entities.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarRental.Business.Interfaces
{
    public interface IGenericService<T> where T: class, IBaseEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
    }
}