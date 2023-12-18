using MangaShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace MangaShop.Models
{
    public static class UserRoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<DefaultUser>>();

            //create roles
            string[] roleNames = { "Admin", "User" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            //log in detauls for admin
            var email = "admin@site.com";
            var password = "Qwerty123!";

            //if no userManager
            if (userManager.FindByEmailAsync(email).Result == null)
            {
                //create user
                DefaultUser user = new()
                {
                    Email = email,
                    UserName = email,
                    FirstName = "Admin",
                    LastName = "Adminsson",
                    Address = "Adstreet 3",
                    City = "Big City",
                    ZipCode = "12345"
                };

                // assign above user as userManager
                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            // log in details for user
            var userEmail = "user@site.com";
            var userPassword = "Qwerty123!";

            if (userManager.FindByEmailAsync(userEmail).Result == null)
            {
                DefaultUser user = new()
                {
                    Email = userEmail,
                    UserName = userEmail,
                    FirstName = "User",
                    LastName = "Usersson",
                    Address = "Userstreet 4",
                    City = "Small City",
                    ZipCode = "12344"
                };

                IdentityResult result = userManager.CreateAsync(user, userPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

        }
    }
}