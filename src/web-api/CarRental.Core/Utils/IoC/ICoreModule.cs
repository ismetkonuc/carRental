using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Core.Utils.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}