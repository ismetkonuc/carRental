using CarRental.Core.Entities;

namespace CarRental.Entities.Dtos.Brand
{
    public class BrandUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}