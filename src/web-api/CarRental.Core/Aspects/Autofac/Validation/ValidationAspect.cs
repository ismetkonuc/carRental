﻿using System;
using System.Linq;
using CarRental.Core.CrossCuttingConcerns.Validation;
using CarRental.Core.Utils.Interceptors;
using CarRental.Core.Utils.Results;
using Castle.DynamicProxy;
using FluentValidation;

namespace CarRental.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("This is not a confirmation class");
                //throw new System.Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            invocation.ReturnValue = new ErrorResult(false, e.Message);
        }
    }
}