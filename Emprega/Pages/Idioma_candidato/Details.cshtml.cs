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
    public class DetailsModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public DetailsModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
