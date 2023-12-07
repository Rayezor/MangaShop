using MangaShop.Data;
using MangaShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Stripe;
using Stripe.Checkout;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace MangaShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly MangashopContext _context;
        private readonly Cart _cart;

        public OrderController(MangashopContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var cartItems = _cart.GetAllCartItems();
            _cart.CartItems = cartItems;

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Cart is empty, please add a book first.");
            }

            if (ModelState.IsValid)
            {
                var domain = "http://localhost:5063/";
                var options = new SessionCreateOptions
                {
                    SuccessUrl = domain + $"Order/OrderConfirmation", //Url.Action("CheckoutComplete", "Order", new { orderId = order.Id }, HttpContext.Request.Scheme),
                    CancelUrl = domain + $"Order/Fail",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment"
                };

                foreach (var item in cartItems)
                {
                    var sessionListItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.Manga.Price*item.Quantity*100),  //(order.OrderTotal * 100),
                            Currency = "eur",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Manga.Title.ToString(),
                            }
                        },
                        Quantity = item.Quantity
                    };
                    options.LineItems.Add(sessionListItem);
                }
                var service = new SessionService();
                Session session = service.Create(options);

                TempData["Session"] = session.Id;
                Response.Headers.Add("Location", session.Url);
                // return View("CheckoutComplete", order);
                return new StatusCodeResult(303);
            }
            return View(cartItems);
        }

        public IActionResult OrderConfirmation(Order order)
        {
            var cartItems = _cart.GetAllCartItems();
            _cart.CartItems = cartItems;
            CreateOrder(order);
            var service = new SessionService();
            Session session = service.Get(TempData["Session"].ToString());
            _cart.ClearCart();

            if (session.PaymentStatus == "paid")
            {
                var transaction = session.PaymentIntentId.ToString();
                return View("CheckoutComplete", order);
            }
            return View("Login");
        }
        public IActionResult Fail()
        {
            return View();
        }

        public IActionResult CheckoutComplete(Order order)
        {
            return View(order);
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var cartItems = _cart.CartItems;

            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem()
                {
                    Quantity = item.Quantity,
                    MangaId = item.Manga.Id,
                    OrderId = order.Id,
                    Price = item.Manga.Price * item.Quantity
                };
                order.OrderItems.Add(orderItem);
                order.OrderTotal += orderItem.Price;
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}