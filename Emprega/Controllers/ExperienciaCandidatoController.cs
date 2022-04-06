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
    public class ExperienciaCandidatoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExperienciaCandidatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ExperienciaCandidato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienciaCandidato>>> GetExperienciaCandidato()
        {
            return await _context.ExperienciaCandidato.ToListAsync();
        }

        // GET: api/ExperienciaCandidato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienciaCandidato>> GetExperienciaCandidato(int id)
        {
            var experienciaCandidato = await _context.ExperienciaCandidato.FindAsync(id);

            if (experienciaCandidato == null)
            {
                return NotFound();
            }

            return experienciaCandidato;
        }

        // PUT: api/ExperienciaCandidato/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperienciaCandidato(int id, ExperienciaCandidato experienciaCandidato)
        {
            if (id != experienciaCandidato.Id)
            {
                return BadRequest();
            }

            _context.Entry(experienciaCandidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienciaCandidatoExists(id))
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

        // POST: api/ExperienciaCandidato
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExperienciaCandidato>> PostExperienciaCandidato(ExperienciaCandidato experienciaCandidato)
        {
            _context.ExperienciaCandidato.Add(experienciaCandidato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperienciaCandidato", new { id = experienciaCandidato.Id }, experienciaCandidato);
        }

        // DELETE: api/ExperienciaCandidato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperienciaCandidato(int id)
        {
            var experienciaCandidato = await _context.ExperienciaCandidato.FindAsync(id);
            if (experienciaCandidato == null)
            {
                return NotFound();
            }

            _context.ExperienciaCandidato.Remove(experienciaCandidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExperienciaCandidatoExists(int id)
        {
            return _context.ExperienciaCandidato.Any(e => e.Id == id);
        }
    }
}
