using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MangaShop.Data;
using MangaShop.Models;

namespace MangaShop.Controllers
{
    public class CartController : Controller
    {
        private readonly MangashopContext _context;
        private readonly Cart _cart;

        public CartController(MangashopContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Index()
        {
            var items = _cart.GetAllCartItems();
            _cart.CartItems = items;

            return View(_cart);
        }

        public IActionResult AddToCart(int id)
        {
            var selectedBook = GetBookById(id);

            if (selectedBook != null)
            {
                _cart.AddToCart(selectedBook, 1);
            }

            return RedirectToAction("Index", "Store");
        }
        public Manga GetBookById(int id)
        {
            return _context.Mangas.FirstOrDefault(b => b.Id == id);
        }
    }
}
