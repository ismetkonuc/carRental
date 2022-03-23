using System.Threading.Tasks;
using CarRental.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace CarRental.API.Initializers
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");

            if (adminRole == null)
                await roleManager.CreateAsync(new AppRole() { Name = "Admin" });

            var memberRole = await roleManager.FindByNameAsync("member");

            if (memberRole == null)
                await roleManager.CreateAsync(new AppRole { Name = "Member" });

            var adminUser = await userManager.FindByNameAsync("admin");

            if (adminUser == null)
            {
                AppUser user = new AppUser()
                {
                    Name = "İsmet",
                    Surname = "Konuç",
                    Email = "ismetkonuc@gmail.com",
                    UserName = "admin"
                };

                await userManager.CreateAsync(user, "1");
                await userManager.AddToRoleAsync(user, "Admin");
            }

        }
    }
}