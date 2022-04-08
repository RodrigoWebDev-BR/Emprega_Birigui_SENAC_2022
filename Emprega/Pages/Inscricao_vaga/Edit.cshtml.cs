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

namespace Emprega.Pages.Inscricao_vaga
{
    public class EditModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public EditModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InscricaoVaga InscricaoVaga { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InscricaoVaga = await _context.InscricaoVaga
                .Include(i => i.IdCandidatoNavigation)
                .Include(i => i.IdStatusNavigation)
                .Include(i => i.IdVagaNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (InscricaoVaga == null)
            {
                return NotFound();
            }
           ViewData["IdCandidato"] = new SelectList(_context.Candidato, "Id", "Id");
           ViewData["IdStatus"] = new SelectList(_context.InscricaoStatus, "Id", "Id");
           ViewData["IdVaga"] = new SelectList(_context.Vaga, "Id", "Id");
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

            _context.Attach(InscricaoVaga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoVagaExists(InscricaoVaga.Id))
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

        private bool InscricaoVagaExists(int id)
        {
            return _context.InscricaoVaga.Any(e => e.Id == id);
        }
    }
}
