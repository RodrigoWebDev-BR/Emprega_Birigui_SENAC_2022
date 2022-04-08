#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Pages.Vaga
{
    public class EditModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public EditModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Vaga Vaga { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vaga = await _context.Vaga
                .Include(v => v.IdAreaAtuacaoNavigation)
                .Include(v => v.IdEmpresaNavigation)
                .Include(v => v.IdTipoContratoNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Vaga == null)
            {
                return NotFound();
            }
           ViewData["IdAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "Id", "Id");
           ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "Id");
           ViewData["IdTipoContrato"] = new SelectList(_context.TipoContrato, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vaga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagaExists(Vaga.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VagaExists(int id)
        {
            return _context.Vaga.Any(e => e.Id == id);
        }
    }
}
