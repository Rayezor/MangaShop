using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using MangaShop.Data;

namespace MangaShop.Models
{
    public class Cart
    {
        private readonly MangashopContext _context;

        public Cart(MangashopContext context)
        {
            _context = context;
        }

        public string Id { get; set; }
        public List<CartItem> CartItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<MangashopContext>();
            string cartId = session.GetString("Id") ?? Guid.NewGuid().ToString();

            session.SetString("Id", cartId);

            return new Cart(context) { Id = cartId };
        }
        public CartItem GetCartItem(Manga manga)
        {
            return _context.CartItems.SingleOrDefault(ci =>ci.Manga.Id == manga.Id && ci.CartId == Id);
        }

        public void AddToCart(Manga manga, int quantity)
        {
            var cartItem = GetCartItem(manga);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Manga = manga,
                    Quantity = quantity,
                    CartId = Id
                };

                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }
            _context.SaveChanges();
        }

        public List<CartItem> GetAllCartItems()
        {
            return CartItems ??
                (CartItems = _context.CartItems.Where(ci => ci.CartId == Id)
                    .Include(ci => ci.Manga)
                    .ToList());
        }
        public int GetCartTotal()
        {
            return (int)_context.CartItems
                .Where(ci => ci.CartId == Id).Select(ci => ci.Manga.Price * ci.Quantity).Sum();
        }
    }
}
