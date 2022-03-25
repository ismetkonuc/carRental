using CarRental.Core.CrossCuttingConcerns.Caching;
using CarRental.Core.Utils.Interceptors;
using CarRental.Core.Utils.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}