using CarRental.Entities.Concrete;
using FluentValidation;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(I => I.Price).NotEmpty();
            RuleFor(I => I.Price).GreaterThan(0);
            RuleFor(I => I.Name).MinimumLength(2);
        }
    }
}