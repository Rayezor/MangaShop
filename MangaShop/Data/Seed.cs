﻿using Microsoft.AspNetCore.Identity;
using MangaShop.Data.Enum;
using MangaShop.Models;
using System.Diagnostics;
using System.Net;
using System.IO.Pipelines;
using MangaShop.Data;

namespace MangaShop.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<MangashopContext>();

            context.Database.EnsureCreated();

            if (!context.Mangas.Any())
            {
                context.Mangas.AddRange(new List<Manga>()
                    {
                        new Manga()
                        {
                            Title = "One Piece",
                            VolumeImage = "/images/one-piece-vol-1.jpg",
                            Description = "This is the description of the first manga",
                            Author = "Oda Eiichiro",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 1,
                            DatePublished = DateTime.Parse("2013-9-26"),
                            Price = 10.0,
                         },
                        new Manga()
                        {
                            Title = "One Piece",
                            VolumeImage = "/images/one-piece-vol-2.jpg",
                            Description = "This is the description of the second manga",
                            Author = "Oda Eiichiro",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 2,
                            DatePublished = DateTime.Parse("2013-9-30"),
                            Price = 10.0,
                         },
                        new Manga()
                        {
                            Title = "Attack on Titan",
                            VolumeImage = "/images/attack-on-titan-vol-1.jpg",
                            Description = "In this post-apocalytpic sci-fi story, humanity has been devastated by the bizarre, giant humanoids known as the Titans. Little is known about where they came from or why they are bent on consuming mankind. Seemingly unintelligent, they have roamed the world for years, killing everyone they see. For the past century, what's left of man has hidden in a giant, three-walled city. People believe their 100-meter-high walls will protect them from the Titans, but the sudden appearance of an immense Titan is about to change everything. Winner of the 2011 Kodansha Manga Award (Shonen) and nominated for the prestigious Osamu Tezuka Cultural Prize for 2012.",
                            Author = "Hajime Isayama",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 2,
                            DatePublished = DateTime.Parse("2010-3-17"),
                            Price = 12.0,
                         },
                    });
                context.SaveChanges();
            }
        }

        /*        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
                {
                    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                    {
                        //Roles
                        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                        if (!await roleManager.RoleExistsAsync(UserRoles.User))
                            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                        //Users
                        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                        string adminUserEmail = "teddysmithdeveloper@gmail.com";

                        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                        if (adminUser == null)
                        {
                            var newAdminUser = new AppUser()
                            {
                                UserName = "teddysmithdev",
                                Email = adminUserEmail,
                                EmailConfirmed = true,
                                Address = new Address()
                                {
                                    Street = "123 Main St",
                                    City = "Charlotte",
                                    State = "NC"
                                }
                            };
                            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                        }

                        string appUserEmail = "user@etickets.com";

                        var appUser = await userManager.FindByEmailAsync(appUserEmail);
                        if (appUser == null)
                        {
                            var newAppUser = new AppUser()
                            {
                                UserName = "app-user",
                                Email = appUserEmail,
                                EmailConfirmed = true,
                                Address = new Address()
                                {
                                    Street = "123 Main St",
                                    City = "Charlotte",
                                    State = "NC"
                                }
                            };
                            await userManager.CreateAsync(newAppUser, "Coding@1234?");
                            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                        }
                    }
                }
            }*/
    }
}
