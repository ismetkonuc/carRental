using CarRental.Core.Entities;
using System.Collections.Generic;
using CarRental.Entities.Dtos.Car;

namespace CarRental.Entities.Dtos.Brand
{
    public class BrandGetDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarGetDto> Cars { get; set; }
    }
}