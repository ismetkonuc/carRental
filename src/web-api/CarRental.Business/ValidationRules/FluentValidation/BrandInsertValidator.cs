using CarRental.Business.Constants;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos.Brand;
using FluentValidation;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class BrandInsertValidator : AbstractValidator<BrandInsertDto>
    {
        public BrandInsertValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage(Messages.EntityNameNotEmpty);
        }
    }
}