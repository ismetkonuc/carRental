using CarRental.Entities.Dtos.Car;
using FluentValidation;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CarUpdateValidator : AbstractValidator<CarUpdateDto>
    {
        public CarUpdateValidator()
        {
            RuleFor(I => I.Price).NotEmpty();
            RuleFor(I => I.Price).GreaterThan(0);
            RuleFor(I => I.Name).MinimumLength(2);
        }
    }
}