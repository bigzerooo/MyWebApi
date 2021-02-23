using DataAccessLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeding
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            string adminUsername = "admin";
            string adminEmail = "admin@gmail.com";
            string password = "Admin_1";
            if (await roleManager.FindByNameAsync("admin") == null)
                await roleManager.CreateAsync(new Role { Name = "admin" });
            if (await roleManager.FindByNameAsync("user") == null)
                await roleManager.CreateAsync(new Role { Name = "user" });
            if (await userManager.FindByNameAsync(adminUsername) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminUsername, ClientId = 1 };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}