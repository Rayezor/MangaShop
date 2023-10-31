using MangaShop.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaShop.Models
{
    public class Manga
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required, Display(Name = "Volume Image")]
        public string VolumeImage { get; set; }
        [MaxLength(100)] 
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required, Display(Name = "Category")]
        public MangaCategory MangaCategory { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Date Published")]
        public DateTime DatePublished { get; set; }
        [Required, DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}
