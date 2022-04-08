#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Emprega.Models;

namespace Emprega.Pages.Vaga_Beneficio
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
        ViewData["IdBeneficio"] = new SelectList(_context.Beneficio, "Id", "Id");
        ViewData["IdVaga"] = new SelectList(_context.Vaga, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public VagaBeneficio VagaBeneficio { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VagaBeneficio.Add(VagaBeneficio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
