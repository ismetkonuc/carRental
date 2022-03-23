using System.Linq;
using CarRental.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using CarRental.Entities.Concrete;
using CarRental.Entities.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.API.Initializers
{
    public static class CarInitializer
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CarRentalDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<CarRentalDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Cars.Any())
            {

                context.Cars.AddRange(
                    
                    new Car(){BrandId = 1, CarType = CarType.Hatchback, Description = "Ehliyet Yaşı 3 ve Üzeri", FuelType = FuelType.Diesel, 
                        GearType = GearType.Automatic, IsReserved = false, Name = "Polo", Year = 2015, Price = 300M},
                    
                    new Car()
                    {
                        BrandId = 2,
                        CarType = CarType.Hatchback,
                        Description = "Ehliyet Yaşı 3 ve Üzeri",
                        FuelType = FuelType.Gasoline,
                        GearType = GearType.Manual,
                        IsReserved = false,
                        Name = "Fabia",
                        Year = 2018,
                        Price = 200M
                    },

                    new Car()
                    {
                        BrandId = 3,
                        CarType = CarType.Sedan,
                        Description = "Ehliyet Yaşı 3 ve Üzeri",
                        FuelType = FuelType.Gasoline,
                        GearType = GearType.Manual,
                        IsReserved = false,
                        Name = "Corolla",
                        Year = 2020,
                        Price = 350M
                    },

                    new Car()
                    {
                        BrandId = 4,
                        CarType = CarType.Hatchback,
                        Description = "Ehliyet Yaşı 3 ve Üzeri",
                        FuelType = FuelType.Gasoline,
                        GearType = GearType.Automatic,
                        IsReserved = false,
                        Name = "i30",
                        Year = 2020,
                        Price = 350M
                    },

                    new Car()
                    {
                        BrandId = 5,
                        CarType = CarType.Sedan,
                        Description = "Ehliyet Yaşı 3 ve Üzeri",
                        FuelType = FuelType.Gasoline,
                        GearType = GearType.Automatic,
                        IsReserved = false,
                        Name = "C200",
                        Year = 2020,
                        Price = 550M
                    },

                    new Car()
                    {
                        BrandId = 6,
                        CarType = CarType.Sedan,
                        Description = "Ehliyet Yaşı 3 ve Üzeri",
                        FuelType = FuelType.Gasoline,
                        GearType = GearType.Automatic,
                        IsReserved = false,
                        Name = "A4",
                        Year = 2021,
                        Price = 550M
                    },

                    new Car()
                    {
                        BrandId = 7,
                        CarType = CarType.SUV,
                        Description = "Ehliyet Yaşı 3 ve Üzeri",
                        FuelType = FuelType.Gasoline,
                        GearType = GearType.Automatic,
                        IsReserved = false,
                        Name = "X3",
                        Year = 2017,
                        Price = 750M
                    },

                    new Car()
                    {
                        BrandId = 8,
                        CarType = CarType.Hatchback,
                        Description = "Ehliyet Yaşı 3 ve Üzeri",
                        FuelType = FuelType.Gasoline,
                        GearType = GearType.Manual,
                        IsReserved = false,
                        Name = "Ibiza",
                        Year = 2017,
                        Price = 350M
                    },

                    new Car()
                    {
                        BrandId = 9,
                        CarType = CarType.Sedan,
                        Description = "Ehliyet Yaşı 3 ve Üzeri",
                        FuelType = FuelType.Gasoline,
                        GearType = GearType.Manual,
                        IsReserved = false,
                        Name = "Focus",
                        Year = 2017,
                        Price = 350M
                    },
                    new Car()
                    {
                        BrandId = 10,
                        CarType = CarType.Sedan,
                        Description = "Ehliyet Yaşı 3 ve Üzeri",
                        FuelType = FuelType.Diesel,
                        GearType = GearType.Manual,
                        IsReserved = false,
                        Name = "Egea",
                        Year = 2021,
                        Price = 350M
                    }
                );

                context.SaveChanges();
            }
        }
    }
}