using CarRental.Core.Entities;

namespace CarRental.Entities.Dtos.Image
{
    public class ImageUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }
}