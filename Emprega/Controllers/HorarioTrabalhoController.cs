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
    public class HorarioTrabalhoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HorarioTrabalhoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HorarioTrabalho
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorarioTrabalho>>> GetHorarioTrabalho()
        {
            return await _context.HorarioTrabalho.ToListAsync();
        }

        // GET: api/HorarioTrabalho/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HorarioTrabalho>> GetHorarioTrabalho(int id)
        {
            var horarioTrabalho = await _context.HorarioTrabalho.FindAsync(id);

            if (horarioTrabalho == null)
            {
                return NotFound();
            }

            return horarioTrabalho;
        }

        // PUT: api/HorarioTrabalho/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorarioTrabalho(int id, HorarioTrabalho horarioTrabalho)
        {
            if (id != horarioTrabalho.Id)
            {
                return BadRequest();
            }

            _context.Entry(horarioTrabalho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioTrabalhoExists(id))
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

        // POST: api/HorarioTrabalho
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HorarioTrabalho>> PostHorarioTrabalho(HorarioTrabalho horarioTrabalho)
        {
            _context.HorarioTrabalho.Add(horarioTrabalho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHorarioTrabalho", new { id = horarioTrabalho.Id }, horarioTrabalho);
        }

        // DELETE: api/HorarioTrabalho/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorarioTrabalho(int id)
        {
            var horarioTrabalho = await _context.HorarioTrabalho.FindAsync(id);
            if (horarioTrabalho == null)
            {
                return NotFound();
            }

            _context.HorarioTrabalho.Remove(horarioTrabalho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HorarioTrabalhoExists(int id)
        {
            return _context.HorarioTrabalho.Any(e => e.Id == id);
        }
    }
}
