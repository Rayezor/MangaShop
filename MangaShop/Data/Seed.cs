using Microsoft.AspNetCore.Identity;
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
                            DatePublished = DateTime.Parse("2013-10-4"),
                            Price = 10.0,
                         },
                        new Manga()
                        {
                            Title = "One Piece",
                            VolumeImage = "/images/one-piece-vol-3.jpg",
                            Description = "This is the description of the third manga",
                            Author = "Oda Eiichiro",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 3,
                            DatePublished = DateTime.Parse("2013-10-8"),
                            Price = 10.0,
                         },
                        new Manga()
                        {
                            Title = "One Piece",
                            VolumeImage = "/images/one-piece-vol-4.jpg",
                            Description = "This is the description of the fourth manga",
                            Author = "Oda Eiichiro",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 4,
                            DatePublished = DateTime.Parse("2013-10-12"),
                            Price = 10.0,
                         },
                        new Manga()
                        {
                            Title = "One Piece",
                            VolumeImage = "/images/one-piece-vol-5.jpg",
                            Description = "This is the description of the fifth manga",
                            Author = "Oda Eiichiro",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 5,
                            DatePublished = DateTime.Parse("2013-10-16"),
                            Price = 10.0,
                         },
                        new Manga()
                        {
                            Title = "Attack on Titan",
                            VolumeImage = "/images/attack-on-titan-vol-1.jpg",
                            Description = "This is the description of the first Titan manga",
                            Author = "Hajime Isayama",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 1,
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
