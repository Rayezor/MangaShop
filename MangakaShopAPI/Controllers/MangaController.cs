using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MangaShop.Data.Enum;
using MangaShop.Models;
using Microsoft.EntityFrameworkCore;
using MangaShop.Data;

[Route("api/[controller]")]
[ApiController]
public class MangaController : ControllerBase
{
    private readonly MangashopContext _context;

    public MangaController(MangashopContext context)
    {
        _context = context;
    }

    // GET: api/Manga
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Manga>>> GetManga()
    {
        return await _context.Mangas.ToListAsync();
    }

    // GET: api/Manga/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Manga>> GetManga(int id)
    {
        var manga = await _context.Mangas.FindAsync(id);

        if (manga == null)
        {
            return NotFound();
        }

        return manga;
    }

    // POST: api/Manga
    [HttpPost]
    public async Task<ActionResult<Manga>> PostManga(Manga manga)
    {
        _context.Mangas.Add(manga);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetManga), new { id = manga.Id }, manga);
    }

    // PUT: api/Manga/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutManga(int id, Manga manga)
    {
        if (id != manga.Id)
        {
            return BadRequest();
        }

        _context.Entry(manga).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MangaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Manga/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteManga(int id)
    {
        var manga = await _context.Mangas.FindAsync(id);
        if (manga == null)
        {
            return NotFound();
        }

        _context.Mangas.Remove(manga);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MangaExists(int id)
    {
        return _context.Mangas.Any(e => e.Id == id);
    }
}