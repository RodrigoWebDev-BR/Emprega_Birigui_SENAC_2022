#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Pages.Vaga
{
    public class DetailsModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public DetailsModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
