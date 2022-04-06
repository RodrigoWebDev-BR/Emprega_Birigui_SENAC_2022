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
    public class InscricaoVagaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InscricaoVagaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InscricaoVaga
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscricaoVaga>>> GetInscricaoVaga()
        {
            return await _context.InscricaoVaga.ToListAsync();
        }

        // GET: api/InscricaoVaga/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InscricaoVaga>> GetInscricaoVaga(int id)
        {
            var inscricaoVaga = await _context.InscricaoVaga.FindAsync(id);

            if (inscricaoVaga == null)
            {
                return NotFound();
            }

            return inscricaoVaga;
        }

        // PUT: api/InscricaoVaga/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscricaoVaga(int id, InscricaoVaga inscricaoVaga)
        {
            if (id != inscricaoVaga.Id)
            {
                return BadRequest();
            }

            _context.Entry(inscricaoVaga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoVagaExists(id))
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

        // POST: api/InscricaoVaga
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InscricaoVaga>> PostInscricaoVaga(InscricaoVaga inscricaoVaga)
        {
            _context.InscricaoVaga.Add(inscricaoVaga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscricaoVaga", new { id = inscricaoVaga.Id }, inscricaoVaga);
        }

        // DELETE: api/InscricaoVaga/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscricaoVaga(int id)
        {
            var inscricaoVaga = await _context.InscricaoVaga.FindAsync(id);
            if (inscricaoVaga == null)
            {
                return NotFound();
            }

            _context.InscricaoVaga.Remove(inscricaoVaga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscricaoVagaExists(int id)
        {
            return _context.InscricaoVaga.Any(e => e.Id == id);
        }
    }
}
