using DataAccessLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeding
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<MyUser> userManager, RoleManager<MyRole> roleManager)//создание ролей "admin" и "user", и самого админа
        {
            string adminUsername = "admin";
            string adminEmail = "admin@gmail.com";
            string password = "Admin_1";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new MyRole { Name = "admin" });
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new MyRole { Name = "user" });
            }
            if (await userManager.FindByNameAsync(adminUsername) == null)
            {
                MyUser admin = new MyUser { Email = adminEmail, UserName = adminUsername };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
