using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CarRental.Core.Entities;
using CarRental.Core.Utils.Results;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos.Rental;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CarRental.Business.Interfaces
{
    public interface IRentalService
    {
        IResult Add(RentalInsertDto entity);
        IResult Update(RentalUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<RentalGetDto>> GetAll(Expression<Func<Rental, bool>> filter = null);
        IDataResult<RentalGetDto> Get(Expression<Func<Rental, bool>> filter);
    }
}