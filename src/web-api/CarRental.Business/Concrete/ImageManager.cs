using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Autofac.Builder;
using CarRental.Business.Interfaces;
using CarRental.Core.Utils.Results;
using CarRental.DataAccess.Interfaces;
using CarRental.Entities.Concrete;

namespace CarRental.Business.Concrete
{
    public class ImageManager : IIMageService
    {
        private readonly IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(Image entity)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Image entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Image>> GetAll(Expression<Func<Image, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Image> Get(Expression<Func<Image, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}