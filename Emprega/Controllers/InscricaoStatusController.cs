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
    public class InscricaoStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InscricaoStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InscricaoStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscricaoStatus>>> GetInscricaoStatus()
        {
            return await _context.InscricaoStatus.ToListAsync();
        }

        // GET: api/InscricaoStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InscricaoStatus>> GetInscricaoStatus(int id)
        {
            var inscricaoStatus = await _context.InscricaoStatus.FindAsync(id);

            if (inscricaoStatus == null)
            {
                return NotFound();
            }

            return inscricaoStatus;
        }

        // PUT: api/InscricaoStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscricaoStatus(int id, InscricaoStatus inscricaoStatus)
        {
            if (id != inscricaoStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(inscricaoStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoStatusExists(id))
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

        // POST: api/InscricaoStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InscricaoStatus>> PostInscricaoStatus(InscricaoStatus inscricaoStatus)
        {
            _context.InscricaoStatus.Add(inscricaoStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscricaoStatus", new { id = inscricaoStatus.Id }, inscricaoStatus);
        }

        // DELETE: api/InscricaoStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscricaoStatus(int id)
        {
            var inscricaoStatus = await _context.InscricaoStatus.FindAsync(id);
            if (inscricaoStatus == null)
            {
                return NotFound();
            }

            _context.InscricaoStatus.Remove(inscricaoStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscricaoStatusExists(int id)
        {
            return _context.InscricaoStatus.Any(e => e.Id == id);
        }
    }
}
