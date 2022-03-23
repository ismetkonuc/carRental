using CarRental.Entities.Concrete;
using FluentValidation;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(I => I.Name).NotEmpty();
        }
    }
}