using Microsoft.AspNetCore.Identity;

namespace CarRental.Core.Entities
{
    public abstract class AppUserBase : IdentityUser<int>, IBaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}