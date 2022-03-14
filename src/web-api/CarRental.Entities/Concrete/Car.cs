using System.Collections.Generic;
using CarRental.Entities.Enums;
using CarRental.Core.Entities;


namespace CarRental.Entities.Concrete
{
    public class Car : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Year { get; set; }
        public FuelType FuelType { get; set; }
        public GearType GearType { get; set; }
        public CarType CarType { get; set; }
        public string Description { get; set; }
        public bool IsReserved { get; set; } = false;
        public decimal Price { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public Rental Rental { get; set; }

        public List<Image> Images { get; set; }
    }
}