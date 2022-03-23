using CarRental.Entities.Concrete;
using FluentValidation;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(I => I.ReturnDate).GreaterThanOrEqualTo(I => I.RentDate);
            RuleFor(I => I.RentDate).LessThanOrEqualTo(I => I.ReturnDate);
        }
    }
}