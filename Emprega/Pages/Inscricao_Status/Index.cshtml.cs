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
    public class IndexModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public IndexModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<InscricaoStatus> InscricaoStatus { get;set; }

        public async Task OnGetAsync()
        {
            InscricaoStatus = await _context.InscricaoStatus.ToListAsync();
        }
    }
}
