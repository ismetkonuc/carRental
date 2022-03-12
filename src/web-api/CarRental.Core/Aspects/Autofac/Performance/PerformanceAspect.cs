using System.Diagnostics;
using CarRental.Core.Utils.Interceptors;
using CarRental.Core.Utils.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {

        private readonly int _interval;
        private readonly Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
                _stopwatch.Reset();
            }
        }
    }
}