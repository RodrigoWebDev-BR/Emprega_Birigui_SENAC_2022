#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Pages.Candidato
{
    public class IndexModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public IndexModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Candidato> Candidato { get;set; }

        public async Task OnGetAsync()
        {
            Candidato = await _context.Candidato
                .Include(c => c.IdAreaAtuacaoNavigation)
                .Include(c => c.IdCidadeNavigation)
                .Include(c => c.IdEstadoCivilNavigation)
                .Include(c => c.IdNivelEscolaridadeNavigation).ToListAsync();
        }
    }
}
