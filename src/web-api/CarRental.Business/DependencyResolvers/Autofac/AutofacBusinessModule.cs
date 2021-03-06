using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using CarRental.Business.Concrete;
using CarRental.Business.Interfaces;
using CarRental.Core.Utils.Interceptors;
using CarRental.Core.Utils.Security.JWT;
using CarRental.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using CarRental.DataAccess.Interfaces;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Module = Autofac.Module;

namespace CarRental.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarRepository>().As<ICarDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandRepository>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<ImageManager>().As<IIMageService>().SingleInstance();
            builder.RegisterType<EfImageRepository>().As<IImageDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalRepository>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<AppUserManager>().As<IAppUserService>().SingleInstance();
            builder.RegisterType<EfAppUserRepository>().As<IAppUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = Assembly.GetExecutingAssembly();
            
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(
                    new ProxyGenerationOptions() { Selector = new AspectInterceptorSelector() })
                .SingleInstance();

        }
    }
}