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
    public class EducacaoCandidatoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EducacaoCandidatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EducacaoCandidato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducacaoCandidato>>> GetEducacaoCandidato()
        {
            return await _context.EducacaoCandidato.ToListAsync();
        }

        // GET: api/EducacaoCandidato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducacaoCandidato>> GetEducacaoCandidato(int id)
        {
            var educacaoCandidato = await _context.EducacaoCandidato.FindAsync(id);

            if (educacaoCandidato == null)
            {
                return NotFound();
            }

            return educacaoCandidato;
        }

        // PUT: api/EducacaoCandidato/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducacaoCandidato(int id, EducacaoCandidato educacaoCandidato)
        {
            if (id != educacaoCandidato.Id)
            {
                return BadRequest();
            }

            _context.Entry(educacaoCandidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducacaoCandidatoExists(id))
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

        // POST: api/EducacaoCandidato
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EducacaoCandidato>> PostEducacaoCandidato(EducacaoCandidato educacaoCandidato)
        {
            _context.EducacaoCandidato.Add(educacaoCandidato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducacaoCandidato", new { id = educacaoCandidato.Id }, educacaoCandidato);
        }

        // DELETE: api/EducacaoCandidato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducacaoCandidato(int id)
        {
            var educacaoCandidato = await _context.EducacaoCandidato.FindAsync(id);
            if (educacaoCandidato == null)
            {
                return NotFound();
            }

            _context.EducacaoCandidato.Remove(educacaoCandidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EducacaoCandidatoExists(int id)
        {
            return _context.EducacaoCandidato.Any(e => e.Id == id);
        }
    }
}
