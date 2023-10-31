using MangaShop.Data;
using MangaShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MangaShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly MangashopContext _context;
        private readonly Cart _cart;

        public CartController(MangashopContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }
    }
}
