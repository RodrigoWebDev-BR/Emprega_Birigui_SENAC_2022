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
    public class IndexModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public IndexModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<InscricaoVaga> InscricaoVaga { get;set; }

        public async Task OnGetAsync()
        {
            InscricaoVaga = await _context.InscricaoVaga
                .Include(i => i.IdCandidatoNavigation)
                .Include(i => i.IdStatusNavigation)
                .Include(i => i.IdVagaNavigation).ToListAsync();
        }
    }
}
