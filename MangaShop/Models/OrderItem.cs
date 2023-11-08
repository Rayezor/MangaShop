namespace MangaShop.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int OrderId { get; set; }
        public int MangaId { get; set; }
        public Order Order { get; set; }
        public Manga Manga { get; set; }

    }
}
