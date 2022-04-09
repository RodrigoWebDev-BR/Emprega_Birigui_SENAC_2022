#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Pages.Inscricao_Status
{
    public class DeleteModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public DeleteModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InscricaoStatus InscricaoStatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InscricaoStatus = await _context.InscricaoStatus.FirstOrDefaultAsync(m => m.Id == id);

            if (InscricaoStatus == null)
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

            InscricaoStatus = await _context.InscricaoStatus.FindAsync(id);

            if (InscricaoStatus != null)
            {
                _context.InscricaoStatus.Remove(InscricaoStatus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
