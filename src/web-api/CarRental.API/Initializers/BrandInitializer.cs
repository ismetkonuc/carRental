using System.Linq;
using CarRental.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using CarRental.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.API.Initializers
{
    public static class BrandInitializer
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CarRentalDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<CarRentalDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Brands.Any())
            {
                context.Brands.AddRange(
                    
                    new Brand(){Name = "Volkswagen"},
                    new Brand() { Name ="Skoda"},
                    new Brand() { Name ="Toyota"},
                    new Brand() {Name = "Hyundai"},
                    new Brand() {Name = "Mercedes"},
                    new Brand() {Name = "Audi"},
                    new Brand() {Name = "BMW"},
                    new Brand() {Name = "Seat"},
                    new Brand() {Name = "Ford"},
                    new Brand() {Name = "Fiat"}
                    
                    );

                context.SaveChanges();
            }

        }
    }
}