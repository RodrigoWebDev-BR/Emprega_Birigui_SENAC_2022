#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Pages.Inscricao_vaga
{
    public class DeleteModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public DeleteModel(Emprega.Models.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InscricaoVaga = await _context.InscricaoVaga.FindAsync(id);

            if (InscricaoVaga != null)
            {
                _context.InscricaoVaga.Remove(InscricaoVaga);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
