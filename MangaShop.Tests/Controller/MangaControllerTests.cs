using System.Reflection;
using MangaShop.Controllers;
using MangaShop.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MangaShop.Tests.Controllers
{
    public class MangasControllerTests
    {
        [Fact]
        public void Constructor_WithValidContext_InitializesContext()
        {
            // Arrange
            var context = new MangashopContext(new DbContextOptions<MangashopContext>());

            // Act
            var controller = new MangasController(context);

            // Assert
            Assert.NotNull(controller);
            var contextField = typeof(MangasController).GetField("_context", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(contextField.GetValue(controller));
        }

        [Fact]
        public void Constructor_WithNullContext_ThrowsArgumentNullException()
        {
            // Act and Assert
            var exception = Record.Exception(() => new MangasController(null));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }
    }
}
