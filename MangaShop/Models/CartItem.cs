namespace MangaShop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Manga Manga { get; set; }
        public int Quantity { get; set; }
        public string CartId { get; set; }
    }
}