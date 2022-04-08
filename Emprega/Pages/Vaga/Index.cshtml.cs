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
    public class IndexModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public IndexModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Vaga> Vaga { get;set; }

        public async Task OnGetAsync()
        {
            Vaga = await _context.Vaga
                .Include(v => v.IdAreaAtuacaoNavigation)
                .Include(v => v.IdEmpresaNavigation)
                .Include(v => v.IdTipoContratoNavigation).ToListAsync();
        }
    }
}
