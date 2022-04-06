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
    public class NivelEscolaridadeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NivelEscolaridadeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NivelEscolaridade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelEscolaridade>>> GetNivelEscolaridade()
        {
            return await _context.NivelEscolaridade.ToListAsync();
        }

        // GET: api/NivelEscolaridade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NivelEscolaridade>> GetNivelEscolaridade(int id)
        {
            var nivelEscolaridade = await _context.NivelEscolaridade.FindAsync(id);

            if (nivelEscolaridade == null)
            {
                return NotFound();
            }

            return nivelEscolaridade;
        }

        // PUT: api/NivelEscolaridade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNivelEscolaridade(int id, NivelEscolaridade nivelEscolaridade)
        {
            if (id != nivelEscolaridade.Id)
            {
                return BadRequest();
            }

            _context.Entry(nivelEscolaridade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NivelEscolaridadeExists(id))
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

        // POST: api/NivelEscolaridade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NivelEscolaridade>> PostNivelEscolaridade(NivelEscolaridade nivelEscolaridade)
        {
            _context.NivelEscolaridade.Add(nivelEscolaridade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNivelEscolaridade", new { id = nivelEscolaridade.Id }, nivelEscolaridade);
        }

        // DELETE: api/NivelEscolaridade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNivelEscolaridade(int id)
        {
            var nivelEscolaridade = await _context.NivelEscolaridade.FindAsync(id);
            if (nivelEscolaridade == null)
            {
                return NotFound();
            }

            _context.NivelEscolaridade.Remove(nivelEscolaridade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NivelEscolaridadeExists(int id)
        {
            return _context.NivelEscolaridade.Any(e => e.Id == id);
        }
    }
}
