using CarRental.Core.Utils.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos.Car;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.Business.Interfaces
{
    public interface ICarService
    {
        IResult Add(CarInsertDto entity);
        IResult Update(CarUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<CarGetDto>> GetAll(Expression<Func<Car, bool>> filter = null);
        IDataResult<CarGetDto> Get(Expression<Func<Car, bool>> filter);
    }
}