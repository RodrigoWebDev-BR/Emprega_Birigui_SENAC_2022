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
    public class VagaBeneficioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VagaBeneficioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VagaBeneficio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VagaBeneficio>>> GetVagaBeneficio()
        {
            return await _context.VagaBeneficio.ToListAsync();
        }

        // GET: api/VagaBeneficio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VagaBeneficio>> GetVagaBeneficio(int id)
        {
            var vagaBeneficio = await _context.VagaBeneficio.FindAsync(id);

            if (vagaBeneficio == null)
            {
                return NotFound();
            }

            return vagaBeneficio;
        }

        // PUT: api/VagaBeneficio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVagaBeneficio(int id, VagaBeneficio vagaBeneficio)
        {
            if (id != vagaBeneficio.Id)
            {
                return BadRequest();
            }

            _context.Entry(vagaBeneficio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagaBeneficioExists(id))
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

        // POST: api/VagaBeneficio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VagaBeneficio>> PostVagaBeneficio(VagaBeneficio vagaBeneficio)
        {
            _context.VagaBeneficio.Add(vagaBeneficio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVagaBeneficio", new { id = vagaBeneficio.Id }, vagaBeneficio);
        }

        // DELETE: api/VagaBeneficio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVagaBeneficio(int id)
        {
            var vagaBeneficio = await _context.VagaBeneficio.FindAsync(id);
            if (vagaBeneficio == null)
            {
                return NotFound();
            }

            _context.VagaBeneficio.Remove(vagaBeneficio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VagaBeneficioExists(int id)
        {
            return _context.VagaBeneficio.Any(e => e.Id == id);
        }
    }
}
