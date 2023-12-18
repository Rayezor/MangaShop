using MangaShop.Controllers;
using MangaShop.Data;
using MangaShop.Data.Enum;
using MangaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaShop.Tests.Controllers
{
    public class MangasControllerTests
    {
        //Create Mock Database to use for testing
        private static async Task<MangashopContext> GetDbContextAsync()
        {
            var databaseContext = MangashopContext.CreateForUnitTest();
            databaseContext.Database.EnsureCreated();

            // adding 10 manga to mock database
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
                }
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        [Fact]
        public async Task Index_ReturnsViewResultWithListOfMangas()
        {
            // Arrange
            var dbContext = await GetDbContextAsync();
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
            var dbContext = await GetDbContextAsync();
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
            var dbContext = await GetDbContextAsync();
            var controller = new MangasController(dbContext);
            var manga = new Manga
            {
                Id = 11,
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

        [Fact]
        public async Task Edit_Post_ReturnsRedirectToActionResult()
        {
            // Arrange
            var dbContext = await GetDbContextAsync();
            var controller = new MangasController(dbContext);
            var manga = new Manga
            {
                Id = 9,
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
            var result = await controller.Edit(9, manga);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task DeleteConfirmed_ReturnsRedirectToActionResult()
        {
            // Arrange
            var dbContext = await GetDbContextAsync();
            var controller = new MangasController(dbContext);

            // Act
            var result = await controller.DeleteConfirmed(9);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Index_ReturnsViewWithModel()
        {
            // Arrange
            var dbContext = await GetDbContextAsync();
            var controller = new StoreController(dbContext);

            // Act
            var result = await controller.Index(null, null, null);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MangaViewModel>(viewResult.ViewData.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task Details_WithValidId_ReturnsViewWithModel()
        {
            // Arrange
            var dbContext = await GetDbContextAsync();
            var controller = new StoreController(dbContext);

            // Act
            var result = await controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Manga>(viewResult.ViewData.Model);
            Assert.NotNull(model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task Details_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var dbContext = await GetDbContextAsync();
            var controller = new StoreController(dbContext);

            // Act
            var result = await controller.Details(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
