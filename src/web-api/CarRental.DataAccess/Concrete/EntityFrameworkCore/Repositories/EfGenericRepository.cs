﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CarRental.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using CarRental.DataAccess.Interfaces;
using CarRental.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity, TContext> : IGenericDal<TEntity>
        where TEntity: class, IBaseEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using TContext context = new TContext();
            var entityToAdd = context.Entry(entity);
            entityToAdd.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using TContext context = new TContext();

            var entityToUpdate = context.Entry(entity);
            entityToUpdate.State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using TContext context = new TContext();

            var entityToDelete = context.Entry(entity);
            entityToDelete.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext context = new TContext();

            return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new TContext();

            return context.Set<TEntity>().SingleOrDefault(filter);
        }
    }
}