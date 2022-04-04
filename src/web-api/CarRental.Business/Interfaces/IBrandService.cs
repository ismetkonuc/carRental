using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Core.Utils.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos.Brand;

namespace CarRental.Business.Interfaces
{
    public interface IBrandService
    {
        IResult Add(BrandInsertDto entity);
        IResult Update(BrandUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<BrandGetDto>> GetAll(Expression<Func<Brand, bool>> filter = null);
        IDataResult<BrandGetDto> Get(Expression<Func<Brand, bool>> filter);
    }
}