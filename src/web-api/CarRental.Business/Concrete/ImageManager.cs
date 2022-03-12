using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Business.Interfaces;
using CarRental.Entities.Concrete;

namespace CarRental.Business.Concrete
{
    public class ImageManager : IIMageService
    {
        public void Add(Image entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Image entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Image entity)
        {
            throw new NotImplementedException();
        }

        public List<Image> GetAll(Expression<Func<Image, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Image Get(Expression<Func<Image, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}