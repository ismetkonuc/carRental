using System.Collections.Generic;
using CarRental.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, IBaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}