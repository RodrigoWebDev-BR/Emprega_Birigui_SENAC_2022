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
    public class IndexModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public IndexModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<IdiomaCandidato> IdiomaCandidato { get;set; }

        public async Task OnGetAsync()
        {
            IdiomaCandidato = await _context.IdiomaCandidato
                .Include(i => i.IdIdiomaNavigation).ToListAsync();
        }
    }
}
