using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Interfaces;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utils.Results;
using CarRental.DataAccess.Interfaces;
using CarRental.Entities.Concrete;

namespace CarRental.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(true);
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
            IDataResult<List<Brand>> result;

            try
            {
                List<Brand> brands = _brandDal.GetAll(filter);

                result = new SuccessDataResult<List<Brand>>(brands, true);
            }
            catch (Exception e)
            {
                result = new ErrorDataResult<List<Brand>>(null, false, e.InnerException?.Message);
            }

            return result;
        }

        public IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}