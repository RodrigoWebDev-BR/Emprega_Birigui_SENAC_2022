#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdiomaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IdiomaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Idioma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Idioma>>> GetIdioma()
        {
            return await _context.Idioma.ToListAsync();
        }

        // GET: api/Idioma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Idioma>> GetIdioma(int id)
        {
            var idioma = await _context.Idioma.FindAsync(id);

            if (idioma == null)
            {
                return NotFound();
            }

            return idioma;
        }

        // PUT: api/Idioma/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdioma(int id, Idioma idioma)
        {
            if (id != idioma.Id)
            {
                return BadRequest();
            }

            _context.Entry(idioma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdiomaExists(id))
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

        // POST: api/Idioma
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Idioma>> PostIdioma(Idioma idioma)
        {
            _context.Idioma.Add(idioma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdioma", new { id = idioma.Id }, idioma);
        }

        // DELETE: api/Idioma/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdioma(int id)
        {
            var idioma = await _context.Idioma.FindAsync(id);
            if (idioma == null)
            {
                return NotFound();
            }

            _context.Idioma.Remove(idioma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdiomaExists(int id)
        {
            return _context.Idioma.Any(e => e.Id == id);
        }
    }
}
