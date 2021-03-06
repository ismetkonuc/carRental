using System;
using CarRental.Business.Constants;
using CarRental.Core.Extensions;
using CarRental.Core.Utils.Interceptors;
using CarRental.Core.Utils.IoC;
using CarRental.Core.Utils.Results;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Business.BusinessAspects.Autofac
{
    //JWT
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;


        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }

            throw new Exception(Messages.AuthorizationDenied);
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            invocation.ReturnValue = new ErrorResult(false, e.Message);
        }
    }
}