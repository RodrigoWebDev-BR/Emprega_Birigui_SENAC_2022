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
    public class BeneficioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BeneficioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Beneficio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beneficio>>> GetBeneficio()
        {
            return await _context.Beneficio.ToListAsync();
        }

        // GET: api/Beneficio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beneficio>> GetBeneficio(int id)
        {
            var beneficio = await _context.Beneficio.FindAsync(id);

            if (beneficio == null)
            {
                return NotFound();
            }

            return beneficio;
        }

        // PUT: api/Beneficio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficio(int id, Beneficio beneficio)
        {
            if (id != beneficio.Id)
            {
                return BadRequest();
            }

            _context.Entry(beneficio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficioExists(id))
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

        // POST: api/Beneficio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beneficio>> PostBeneficio(Beneficio beneficio)
        {
            _context.Beneficio.Add(beneficio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeneficio", new { id = beneficio.Id }, beneficio);
        }

        // DELETE: api/Beneficio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficio(int id)
        {
            var beneficio = await _context.Beneficio.FindAsync(id);
            if (beneficio == null)
            {
                return NotFound();
            }

            _context.Beneficio.Remove(beneficio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeneficioExists(int id)
        {
            return _context.Beneficio.Any(e => e.Id == id);
        }
    }
}
