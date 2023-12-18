using MangaShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MangaShop.Models;

namespace MangaShop.Controllers
{
    //allow all users to access this controller
    [AllowAnonymous]
    public class StoreController : Controller
    {
        //Database setup
        private readonly MangashopContext _context;

        public StoreController(MangashopContext context)
        {
            _context = context;
        }

        //filter search
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString, string minPrice, string maxPrice, int page = 1, int pageSize = 8)
        {
            var books = _context.Mangas.Select(b => b);

            //seach by title name or author
            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title.Contains(searchString) || b.Author.Contains(searchString));
            }

            //filter by minimum price
            if (!string.IsNullOrEmpty(minPrice))
            {
                var min = int.Parse(minPrice);
                books = books.Where(b => b.Price >= min);
            }

            //filter by mazimum price
            if (!string.IsNullOrEmpty(maxPrice))
            {
                var max = int.Parse(maxPrice);
                books = books.Where(b => b.Price <= max);
            }

            // Calculate total count before pagination
            var totalCount = await books.CountAsync();

            // Apply pagination
            var paginatedBooks = await books.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // ViewModel to hold paginated data
            var viewModel = new MangaViewModel
            {
                Mangas = paginatedBooks,
                PageNumber = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                SearchString = searchString,
                MinPrice = minPrice,
                MaxPrice = maxPrice
            };

            return View(viewModel);
        }

        //Details page for specific Manga by id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Mangas.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}
