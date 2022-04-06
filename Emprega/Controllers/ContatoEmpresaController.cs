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
    public class ContatoEmpresaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContatoEmpresaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ContatoEmpresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContatoEmpresa>>> GetContatoEmpresa()
        {
            return await _context.ContatoEmpresa.ToListAsync();
        }

        // GET: api/ContatoEmpresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContatoEmpresa>> GetContatoEmpresa(int id)
        {
            var contatoEmpresa = await _context.ContatoEmpresa.FindAsync(id);

            if (contatoEmpresa == null)
            {
                return NotFound();
            }

            return contatoEmpresa;
        }

        // PUT: api/ContatoEmpresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContatoEmpresa(int id, ContatoEmpresa contatoEmpresa)
        {
            if (id != contatoEmpresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(contatoEmpresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoEmpresaExists(id))
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

        // POST: api/ContatoEmpresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContatoEmpresa>> PostContatoEmpresa(ContatoEmpresa contatoEmpresa)
        {
            _context.ContatoEmpresa.Add(contatoEmpresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContatoEmpresa", new { id = contatoEmpresa.Id }, contatoEmpresa);
        }

        // DELETE: api/ContatoEmpresa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContatoEmpresa(int id)
        {
            var contatoEmpresa = await _context.ContatoEmpresa.FindAsync(id);
            if (contatoEmpresa == null)
            {
                return NotFound();
            }

            _context.ContatoEmpresa.Remove(contatoEmpresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContatoEmpresaExists(int id)
        {
            return _context.ContatoEmpresa.Any(e => e.Id == id);
        }
    }
}
