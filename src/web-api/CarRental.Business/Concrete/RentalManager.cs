using AutoMapper;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Business.Constants;
using CarRental.Business.Interfaces;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Aspects.Autofac.Validation;
using CarRental.Core.Utils.Results;
using CarRental.DataAccess.Interfaces;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos.Rental;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly IMapper _mapper;

        public RentalManager(IRentalDal rentalDal, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(RentalInsertDto entity)
        {
            Rental convertedEntity = _mapper.Map<Rental>(entity);
            _rentalDal.Add(convertedEntity);

            return new SuccessResult(true, Messages.EntityAdded);
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(RentalUpdateDto entity)
        {
            var convertedEntity = _mapper.Map<Rental>(entity);
            var rental = _rentalDal.Get(I => I.Id == convertedEntity.Id);

            if (rental != null)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(true, Messages.EntityUpdated);
            }

            return new ErrorResult(false, Messages.EntityNotFound);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(int id)
        {
            var entity = _rentalDal.Get(I => I.Id == id);

            if (entity != null)
            {
                _rentalDal.Delete(entity);

                return new SuccessResult(true, Messages.EntityDeleted);
            }

            return new ErrorResult(false, Messages.EntityNotFound);

        }

        public IDataResult<List<RentalGetDto>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            var rentals = _rentalDal.Get(filter);
            var convertedRentals = _mapper.Map<List<RentalGetDto>>(rentals);
            return new DataResult<List<RentalGetDto>>(convertedRentals, true);
        }

        public IDataResult<RentalGetDto> Get(Expression<Func<Rental, bool>> filter)
        {
            var rental = _rentalDal.Get(filter);
            var convertedRental = _mapper.Map<RentalGetDto>(rental);
            return new DataResult<RentalGetDto>(convertedRental, true);
        }
    }
}