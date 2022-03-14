﻿using FluentValidation;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace CarRental.Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity); // <TEntityObject, TValidatorObject>
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
        }
    }
}