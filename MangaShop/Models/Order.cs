using System;
using System.Collections.Generic;

namespace MangaShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public string PaymentIntentId { get; set; }
    }
}