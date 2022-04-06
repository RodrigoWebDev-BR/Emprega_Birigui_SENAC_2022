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
    public class TipoContatoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoContatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoContato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoContato>>> GetTipoContato()
        {
            return await _context.TipoContato.ToListAsync();
        }

        // GET: api/TipoContato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoContato>> GetTipoContato(int id)
        {
            var tipoContato = await _context.TipoContato.FindAsync(id);

            if (tipoContato == null)
            {
                return NotFound();
            }

            return tipoContato;
        }

        // PUT: api/TipoContato/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoContato(int id, TipoContato tipoContato)
        {
            if (id != tipoContato.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoContato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoContatoExists(id))
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

        // POST: api/TipoContato
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoContato>> PostTipoContato(TipoContato tipoContato)
        {
            _context.TipoContato.Add(tipoContato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoContato", new { id = tipoContato.Id }, tipoContato);
        }

        // DELETE: api/TipoContato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoContato(int id)
        {
            var tipoContato = await _context.TipoContato.FindAsync(id);
            if (tipoContato == null)
            {
                return NotFound();
            }

            _context.TipoContato.Remove(tipoContato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoContatoExists(int id)
        {
            return _context.TipoContato.Any(e => e.Id == id);
        }
    }
}
