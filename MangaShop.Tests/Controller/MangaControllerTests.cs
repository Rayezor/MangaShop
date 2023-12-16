using System.Reflection;
using MangaShop.Controllers;
using MangaShop.Data;
using MangaShop.Data.Enum;
using MangaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MangaShop.Tests.Controllers
{
    public class MangasControllerTests
    {
        private static async Task<MangashopContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<MangashopContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new MangashopContext(options);
            databaseContext.Database.EnsureCreated();
            if (!await databaseContext.Mangas.AnyAsync())
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Mangas.Add(new Manga
                    {
                        Id = i + 1,
                        Title = $"Test Piece {i + 1}",
                        VolumeImage = "Test.jpg",
                        Description = "Test description",
                        Author = "Test Eiichiro",
                        MangaCategory = MangaCategory.Shonen,
                        Genre = Genre.Action,
                        Volume = 1,
                        DatePublished = DateTime.Now,
                        Price = 10.0M,
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async Task Index_ReturnsViewResultWithListOfMangas()
        {
            // Arrange
            var dbContext = await GetDbContext();
            var controller = new MangasController(dbContext);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Manga>>(viewResult.ViewData.Model);
            Assert.Equal(10, model.Count);
        }

        [Fact]
        public async Task Details_ReturnsViewResultWithManga()
        {
            // Arrange
            var dbContext = await GetDbContext();
            var controller = new MangasController(dbContext);

            // Act
            var result = await controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Manga>(viewResult.ViewData.Model);
            Assert.Equal("Test Piece 1", model.Title);
        }

        [Fact]
        public async Task Create_Post_ReturnsRedirectToActionResult()
        {
            // Arrange
            var dbContext = await GetDbContext();
            var controller = new MangasController(dbContext);
            var manga = new Manga
            {
                Id = 99,
                Title = $"Test Piece 99",
                VolumeImage = "Test.jpg",
                Description = "Test description",
                Author = "Test Eiichiro",
                MangaCategory = MangaCategory.Shonen,
                Genre = Genre.Action,
                Volume = 1,
                DatePublished = DateTime.Now,
                Price = 10.0M,
            };

            // Act
            var result = await controller.Create(manga);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

/*        [Fact]
        public async Task Edit_Post_ReturnsRedirectToActionResult()
        {
            // Arrange
            var dbContext = await GetDbContext();
            var controller = new MangasController(dbContext);
            var manga = new Manga
            {
                Id = 11,
                Title = "Updated Manga 1",
                VolumeImage = "Test.jpg",
                Description = "Test description",
                Author = "Test Eiichiro",
                MangaCategory = MangaCategory.Shonen,
                Genre = Genre.Action,
                Volume = 1,
                DatePublished = DateTime.Now,
                Price = 10.0M,
            };

            // Act
            var result = await controller.Edit(11, manga);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }*/

        [Fact]
        public async Task DeleteConfirmed_ReturnsRedirectToActionResult()
        {
            // Arrange
            var dbContext = await GetDbContext();
            var controller = new MangasController(dbContext);

            // Act
            var result = await controller.DeleteConfirmed(99);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
