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
    public class TipoContratoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoContratoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoContrato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoContrato>>> GetTipoContrato()
        {
            return await _context.TipoContrato.ToListAsync();
        }

        // GET: api/TipoContrato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoContrato>> GetTipoContrato(int id)
        {
            var tipoContrato = await _context.TipoContrato.FindAsync(id);

            if (tipoContrato == null)
            {
                return NotFound();
            }

            return tipoContrato;
        }

        // PUT: api/TipoContrato/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoContrato(int id, TipoContrato tipoContrato)
        {
            if (id != tipoContrato.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoContrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoContratoExists(id))
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

        // POST: api/TipoContrato
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoContrato>> PostTipoContrato(TipoContrato tipoContrato)
        {
            _context.TipoContrato.Add(tipoContrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoContrato", new { id = tipoContrato.Id }, tipoContrato);
        }

        // DELETE: api/TipoContrato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoContrato(int id)
        {
            var tipoContrato = await _context.TipoContrato.FindAsync(id);
            if (tipoContrato == null)
            {
                return NotFound();
            }

            _context.TipoContrato.Remove(tipoContrato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoContratoExists(int id)
        {
            return _context.TipoContrato.Any(e => e.Id == id);
        }
    }
}
