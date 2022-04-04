using CarRental.Business.Constants;
using CarRental.Entities.Dtos.Brand;
using FluentValidation;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class BrandUpdateValidator : AbstractValidator<BrandUpdateDto>
    {
        public BrandUpdateValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage(Messages.EntityNameNotEmpty);
        }
    }
}