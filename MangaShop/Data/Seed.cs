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
                            Description = "This is the description of the first Pirate manga",
                            Author = "Oda Eiichiro",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 1,
                            DatePublished = DateTime.Parse("2013-9-26"),
                            Price = 10.0M,
                         },
                        new Manga()
                        {
                            Title = "One Piece",
                            VolumeImage = "/images/one-piece-vol-2.jpg",
                            Description = "This is the description of the second Pirate manga",
                            Author = "Oda Eiichiro",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 2,
                            DatePublished = DateTime.Parse("2013-10-4"),
                            Price = 10.0M,
                         },
                        new Manga()
                        {
                            Title = "One Piece",
                            VolumeImage = "/images/one-piece-vol-3.jpg",
                            Description = "This is the description of the third Pirate manga",
                            Author = "Oda Eiichiro",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 3,
                            DatePublished = DateTime.Parse("2013-10-8"),
                            Price = 10.0M,
                         },
                        new Manga()
                        {
                            Title = "One Piece",
                            VolumeImage = "/images/one-piece-vol-4.jpg",
                            Description = "This is the description of the fourth Pirate manga",
                            Author = "Oda Eiichiro",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 4,
                            DatePublished = DateTime.Parse("2013-10-12"),
                            Price = 10.0M,
                         },
                        new Manga()
                        {
                            Title = "One Piece",
                            VolumeImage = "/images/one-piece-vol-5.jpg",
                            Description = "This is the description of the fifth Pirate manga",
                            Author = "Oda Eiichiro",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 5,
                            DatePublished = DateTime.Parse("2013-10-16"),
                            Price = 10.0M,
                         },
                        new Manga()
                        {
                            Title = "Attack on Titan",
                            VolumeImage = "/images/attack-on-titan-vol-1.jpg",
                            Description = "This is the description of the first Titan manga",
                            Author = "Hajime Isayama",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Horror,
                            Volume = 1,
                            DatePublished = DateTime.Parse("2010-3-17"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Attack on Titan",
                            VolumeImage = "/images/attack-on-titan-vol-2.jpg",
                            Description = "This is the description of the second Titan manga",
                            Author = "Hajime Isayama",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Horror,
                            Volume = 2,
                            DatePublished = DateTime.Parse("2010-3-23"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Attack on Titan",
                            VolumeImage = "/images/attack-on-titan-vol-3.jpg",
                            Description = "This is the description of the third Titan manga",
                            Author = "Hajime Isayama",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Horror,
                            Volume = 3,
                            DatePublished = DateTime.Parse("2010-3-30"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Attack on Titan",
                            VolumeImage = "/images/attack-on-titan-vol-4.jpg",
                            Description = "This is the description of the fourth Titan manga",
                            Author = "Hajime Isayama",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Horror,
                            Volume = 4,
                            DatePublished = DateTime.Parse("2010-3-7"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Attack on Titan",
                            VolumeImage = "/images/attack-on-titan-vol-5.jpg",
                            Description = "This is the description of the fifth Titan manga",
                            Author = "Hajime Isayama",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Horror,
                            Volume = 5,
                            DatePublished = DateTime.Parse("2010-3-14"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Jujutsu Kaisen",
                            VolumeImage = "/images/jujutsu-kaisen-vol-1.jpg",
                            Description = "This is the description of the first Curse manga",
                            Author = "Gege Akutami",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 1,
                            DatePublished = DateTime.Parse("2018-7-4"),
                            Price = 14.0M,
                         },
                        new Manga()
                        {
                            Title = "Jujutsu Kaisen",
                            VolumeImage = "/images/jujutsu-kaisen-vol-2.jpg",
                            Description = "This is the description of the second Curse manga",
                            Author = "Gege Akutami",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 2,
                            DatePublished = DateTime.Parse("2018-9-4"),
                            Price = 14.0M,
                         },
                        new Manga()
                        {
                            Title = "Jujutsu Kaisen",
                            VolumeImage = "/images/jujutsu-kaisen-vol-3.jpg",
                            Description = "This is the description of the third Curse manga",
                            Author = "Gege Akutami",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 3,
                            DatePublished = DateTime.Parse("2010-3-14"),
                            Price = 14.0M,
                         },
                        new Manga()
                        {
                            Title = "Jujutsu Kaisen",
                            VolumeImage = "/images/jujutsu-kaisen-vol-4.jpg",
                            Description = "This is the description of the fourth Curse manga",
                            Author = "Gege Akutami",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 4,
                            DatePublished = DateTime.Parse("2010-3-14"),
                            Price = 14.0M,
                         },
                        new Manga()
                        {
                            Title = "Jujutsu Kaisen",
                            VolumeImage = "/images/jujutsu-kaisen-vol-5.jpg",
                            Description = "This is the description of the fifth Curse manga",
                            Author = "Gege Akutami",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 5,
                            DatePublished = DateTime.Parse("2010-3-14"),
                            Price = 14.0M,
                         },
                        new Manga()
                        {
                            Title = "Demon Slayer",
                            VolumeImage = "/images/demon-slayer-kimetsu-no-yaiba-vol-1.jpg",
                            Description = "This is the description of the first Demon manga",
                            Author = "Koyoharu Gotouge",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 1,
                            DatePublished = DateTime.Parse("2016-6-3"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Demon Slayer",
                            VolumeImage = "/images/demon-slayer-kimetsu-no-yaiba-vol-2.jpg",
                            Description = "This is the description of the second Demon manga",
                            Author = "Koyoharu Gotouge",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 2,
                            DatePublished = DateTime.Parse("2016-8-4"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Demon Slayer",
                            VolumeImage = "/images/demon-slayer-kimetsu-no-yaiba-vol-3.jpg",
                            Description = "This is the description of the third Demon manga",
                            Author = "Koyoharu Gotouge",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 3,
                            DatePublished = DateTime.Parse("2016-10-4"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Demon Slayer",
                            VolumeImage = "/images/demon-slayer-kimetsu-no-yaiba-vol-4.jpg",
                            Description = "This is the description of the fourth Demon manga",
                            Author = "Koyoharu Gotouge",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 4,
                            DatePublished = DateTime.Parse("2016-12-2"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Demon Slayer",
                            VolumeImage = "/images/demon-slayer-kimetsu-no-yaiba-vol-5.jpg",
                            Description = "This is the description of the fifth Demon manga",
                            Author = "Koyoharu Gotouge",
                            MangaCategory = MangaCategory.Seinen,
                            Genre = Genre.Action,
                            Volume = 5,
                            DatePublished = DateTime.Parse("2017-3-3"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "HunterXHunter",
                            VolumeImage = "/images/hunter-x-hunter-vol-1.jpg",
                            Description = "This is the description of the first Hunter manga",
                            Author = "Yoshihiro Togashi",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 1,
                            DatePublished = DateTime.Parse("1998-6-4"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "HunterXHunter",
                            VolumeImage = "/images/hunter-x-hunter-vol-2.jpg",
                            Description = "This is the description of the second Hunter manga",
                            Author = "Yoshihiro Togashi",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 2,
                            DatePublished = DateTime.Parse("1998-9-14"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "HunterXHunter",
                            VolumeImage = "/images/hunter-x-hunter-vol-3.jpg",
                            Description = "This is the description of the third Hunter manga",
                            Author = "Yoshihiro Togashi",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 3,
                            DatePublished = DateTime.Parse("1998-11-14"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "HunterXHunter",
                            VolumeImage = "/images/hunter-x-hunter-vol-4.jpg",
                            Description = "This is the description of the fourth Hunter manga",
                            Author = "Yoshihiro Togashi",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 4,
                            DatePublished = DateTime.Parse("1999-2-4"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "HunterXHunter",
                            VolumeImage = "/images/hunter-x-hunter-vol-5.jpg",
                            Description = "This is the description of the fifth Hunter manga",
                            Author = "Yoshihiro Togashi",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.Action,
                            Volume = 5,
                            DatePublished = DateTime.Parse("1999-4-30"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Fullmetal Alchemist",
                            VolumeImage = "/images/fullmetal-alchemist-vol-1.jpg",
                            Description = "This is the description of the first Alchemy manga",
                            Author = "Hiromu Arakawa",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.SciFi,
                            Volume = 1,
                            DatePublished = DateTime.Parse("2001-7-12"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Fullmetal Alchemist",
                            VolumeImage = "/images/fullmetal-alchemist-vol-2.jpg",
                            Description = "This is the description of the second Alchemy manga",
                            Author = "Hiromu Arakawa",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.SciFi,
                            Volume = 2,
                            DatePublished = DateTime.Parse("2005-5-7"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Fullmetal Alchemist",
                            VolumeImage = "/images/fullmetal-alchemist-vol-3.jpg",
                            Description = "This is the description of the third Alchemy manga",
                            Author = "Hiromu Arakawa",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.SciFi,
                            Volume = 3,
                            DatePublished = DateTime.Parse("2005-9-6"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Fullmetal Alchemist",
                            VolumeImage = "/images/fullmetal-alchemist-vol-4.jpg",
                            Description = "This is the description of the fourth Alchemy manga",
                            Author = "Hiromu Arakawa",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.SciFi,
                            Volume = 4,
                            DatePublished = DateTime.Parse("2003-1-22"),
                            Price = 12.0M,
                         },
                        new Manga()
                        {
                            Title = "Fullmetal Alchemist",
                            VolumeImage = "/images/fullmetal-alchemist-vol-5.jpg",
                            Description = "This is the description of the fifth Alchemy manga",
                            Author = "Hiromu Arakawa",
                            MangaCategory = MangaCategory.Shonen,
                            Genre = Genre.SciFi,
                            Volume = 5,
                            DatePublished = DateTime.Parse("2005-9-20"),
                            Price = 12.0M,
                         },
                    });
                context.SaveChanges();
            }
        }
    }
}
