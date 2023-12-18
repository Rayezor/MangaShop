using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MangaShop.Data;
using MangaShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace MangaShop.Controllers
{
    // Only allows Role of Admin to access this controller. 
    [Authorize(Roles = "Admin")]
    public class MangasController : Controller
    {
        // Database setup
        private readonly MangashopContext _context;

        public MangasController(MangashopContext context)
        { 
            _context = context;
        }

        // GET: Mangas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Mangas.ToListAsync());
        }

        // GET: Mangas/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mangas == null)
            {
                return NotFound();
            }

            var manga = await _context.Mangas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manga == null)
            {
                return NotFound();
            }

            return View(manga);
        }

        // GET: Mangas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mangas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,VolumeImage,Description,Author,MangaCategory,Genre,Volume,DatePublished,Price")] Manga manga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manga);
        }

        // GET: Mangas/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mangas == null)
            {
                return NotFound();
            }

            var manga = await _context.Mangas.FindAsync(id);
            if (manga == null)
            {
                return NotFound();
            }
            return View(manga);
        }

        // POST: Mangas/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,VolumeImage,Description,Author,MangaCategory,Genre,Volume,DatePublished,Price")] Manga manga)
        {
            if (id != manga.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if the entity is already in the context
                    var existingManga = await _context.Mangas.FindAsync(id);
                    if (existingManga != null)
                    {
                        // Update the existing entity
                        _context.Entry(existingManga).CurrentValues.SetValues(manga);
                        _context.Update(existingManga);
                    }
                    else
                    {
                        // The entity is not in the context, attach and update
                        _context.Update(manga);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MangaExists(manga.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(manga);
        }

        // GET: Mangas/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mangas == null)
            {
                return NotFound();
            }

            var manga = await _context.Mangas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manga == null)
            {
                return NotFound();
            }

            return View(manga);
        }

        // POST: Mangas/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mangas == null)
            {
                return Problem("Entity set 'MangakashopContext.Mangas'  is null.");
            }
            var manga = await _context.Mangas.FindAsync(id);
            if (manga != null)
            {
                _context.Mangas.Remove(manga);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Check if a Manga exists using id
        public bool MangaExists(int id)
        {
          return _context.Mangas.Any(e => e.Id == id);
        }
    }
}
