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

namespace Emprega.Pages.Idioma_candidato
{
    public class EditModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public EditModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IdiomaCandidato IdiomaCandidato { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IdiomaCandidato = await _context.IdiomaCandidato
                .Include(i => i.IdIdiomaNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (IdiomaCandidato == null)
            {
                return NotFound();
            }
           ViewData["IdIdioma"] = new SelectList(_context.Idioma, "Id", "Nome");
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

            _context.Attach(IdiomaCandidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdiomaCandidatoExists(IdiomaCandidato.Id))
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

        private bool IdiomaCandidatoExists(int id)
        {
            return _context.IdiomaCandidato.Any(e => e.Id == id);
        }
    }
}
