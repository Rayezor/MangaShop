using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection.PortableExecutable;

namespace MangaShop.Data.Enum
{
    public enum Genre
    {
        Action,
        Adventure,
        Comedy,
        Drama,
        [Display(Name = "Slice of Life")]
        SliceofLife,
        Fantasy,
        Magic,
        Supernatural,
        Horror,
        Mystery,
        Psychological,
        Romance,
        [Display(Name = "Sci-Fi")]
        SciFi
    }
}
