using CarRental.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Entities.Concrete
{
    public class AppRole : IdentityRole<int>, IBaseEntity
    {
        
    }
}