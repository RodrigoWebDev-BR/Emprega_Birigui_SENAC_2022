#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Pages.Idioma_candidato
{
    public class DeleteModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public DeleteModel(Emprega.Models.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IdiomaCandidato = await _context.IdiomaCandidato.FindAsync(id);

            if (IdiomaCandidato != null)
            {
                _context.IdiomaCandidato.Remove(IdiomaCandidato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
