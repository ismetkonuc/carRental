using CarRental.Core.Entities;

namespace CarRental.Entities.Dtos.AppUser
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}