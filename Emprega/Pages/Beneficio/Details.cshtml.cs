#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Pages.Beneficio
{
    public class DetailsModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public DetailsModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Beneficio Beneficio { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Beneficio = await _context.Beneficio.FirstOrDefaultAsync(m => m.Id == id);

            if (Beneficio == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
