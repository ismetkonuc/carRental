using System.Collections.Generic;
using CarRental.Core.Entities;
using CarRental.Entities.Concrete;
using CarRental.Entities.Dtos.Image;
using CarRental.Entities.Enums;

namespace CarRental.Entities.Dtos.Car
{
    public class CarUpdateDto : IDto
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

        public List<ImageGetDto> Images { get; set; }
    }
}