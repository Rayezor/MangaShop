namespace MangaShop.Models
{
    public class MangaViewModel
    {
        public List<Manga> Mangas { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string SearchString { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }

        // Calculate TotalPages based on TotalCount and PageSize
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
