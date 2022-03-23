using System.Collections.Generic;
using System.Security.Claims;
using CarRental.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Entities.Concrete
{
    public class AppUser : AppUserBase
    {
        public List<Rental> Rentals { get; set; }

    }
}