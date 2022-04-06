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
    public class EstadoCivilController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstadoCivilController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoCivil
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoCivil>>> GetEstadoCivil()
        {
            return await _context.EstadoCivil.ToListAsync();
        }

        // GET: api/EstadoCivil/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoCivil>> GetEstadoCivil(int id)
        {
            var estadoCivil = await _context.EstadoCivil.FindAsync(id);

            if (estadoCivil == null)
            {
                return NotFound();
            }

            return estadoCivil;
        }

        // PUT: api/EstadoCivil/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoCivil(int id, EstadoCivil estadoCivil)
        {
            if (id != estadoCivil.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoCivil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoCivilExists(id))
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

        // POST: api/EstadoCivil
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoCivil>> PostEstadoCivil(EstadoCivil estadoCivil)
        {
            _context.EstadoCivil.Add(estadoCivil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoCivil", new { id = estadoCivil.Id }, estadoCivil);
        }

        // DELETE: api/EstadoCivil/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoCivil(int id)
        {
            var estadoCivil = await _context.EstadoCivil.FindAsync(id);
            if (estadoCivil == null)
            {
                return NotFound();
            }

            _context.EstadoCivil.Remove(estadoCivil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoCivilExists(int id)
        {
            return _context.EstadoCivil.Any(e => e.Id == id);
        }
    }
}
