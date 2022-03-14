﻿using System;
using Castle.DynamicProxy;

namespace CarRental.Core.Utils.Interceptors
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public abstract class MethodInterceptionBaseAttribute: Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}