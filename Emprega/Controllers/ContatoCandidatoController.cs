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
    public class ContatoCandidatoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContatoCandidatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ContatoCandidato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContatoCandidato>>> GetContatoCandidato()
        {
            return await _context.ContatoCandidato.ToListAsync();
        }

        // GET: api/ContatoCandidato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContatoCandidato>> GetContatoCandidato(int id)
        {
            var contatoCandidato = await _context.ContatoCandidato.FindAsync(id);

            if (contatoCandidato == null)
            {
                return NotFound();
            }

            return contatoCandidato;
        }

        // PUT: api/ContatoCandidato/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContatoCandidato(int id, ContatoCandidato contatoCandidato)
        {
            if (id != contatoCandidato.Id)
            {
                return BadRequest();
            }

            _context.Entry(contatoCandidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoCandidatoExists(id))
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

        // POST: api/ContatoCandidato
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContatoCandidato>> PostContatoCandidato(ContatoCandidato contatoCandidato)
        {
            _context.ContatoCandidato.Add(contatoCandidato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContatoCandidato", new { id = contatoCandidato.Id }, contatoCandidato);
        }

        // DELETE: api/ContatoCandidato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContatoCandidato(int id)
        {
            var contatoCandidato = await _context.ContatoCandidato.FindAsync(id);
            if (contatoCandidato == null)
            {
                return NotFound();
            }

            _context.ContatoCandidato.Remove(contatoCandidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContatoCandidatoExists(int id)
        {
            return _context.ContatoCandidato.Any(e => e.Id == id);
        }
    }
}
