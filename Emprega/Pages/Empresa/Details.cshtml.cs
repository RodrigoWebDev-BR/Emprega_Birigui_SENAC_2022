#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Pages.Empresa
{
    public class DetailsModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public DetailsModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Empresa Empresa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empresa = await _context.Empresa
                .Include(e => e.IdAreaAtuacaoNavigation)
                .Include(e => e.IdCidadeNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Empresa == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
