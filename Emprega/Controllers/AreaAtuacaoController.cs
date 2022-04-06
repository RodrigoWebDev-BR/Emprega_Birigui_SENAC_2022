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
    public class AreaAtuacaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AreaAtuacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AreaAtuacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaAtuacao>>> GetAreaAtuacao()
        {
            return await _context.AreaAtuacao.ToListAsync();
        }

        // GET: api/AreaAtuacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AreaAtuacao>> GetAreaAtuacao(int id)
        {
            var areaAtuacao = await _context.AreaAtuacao.FindAsync(id);

            if (areaAtuacao == null)
            {
                return NotFound();
            }

            return areaAtuacao;
        }

        // PUT: api/AreaAtuacao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreaAtuacao(int id, AreaAtuacao areaAtuacao)
        {
            if (id != areaAtuacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(areaAtuacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaAtuacaoExists(id))
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

        // POST: api/AreaAtuacao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AreaAtuacao>> PostAreaAtuacao(AreaAtuacao areaAtuacao)
        {
            _context.AreaAtuacao.Add(areaAtuacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAreaAtuacao", new { id = areaAtuacao.Id }, areaAtuacao);
        }

        // DELETE: api/AreaAtuacao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAreaAtuacao(int id)
        {
            var areaAtuacao = await _context.AreaAtuacao.FindAsync(id);
            if (areaAtuacao == null)
            {
                return NotFound();
            }

            _context.AreaAtuacao.Remove(areaAtuacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaAtuacaoExists(int id)
        {
            return _context.AreaAtuacao.Any(e => e.Id == id);
        }
    }
}
