#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Emprega.Models;

namespace Emprega.Pages.Beneficio
{
    public class CreateModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public CreateModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Beneficio Beneficio { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Beneficio.Add(Beneficio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
