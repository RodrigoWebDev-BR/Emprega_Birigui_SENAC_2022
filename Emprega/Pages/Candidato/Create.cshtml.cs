#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Emprega.Models;

namespace Emprega.Pages.Candidato
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
        ViewData["IdAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "Id", "Id");
        ViewData["IdCidade"] = new SelectList(_context.Cidade, "Id", "Id");
        ViewData["IdEstadoCivil"] = new SelectList(_context.EstadoCivil, "Id", "Id");
        ViewData["IdNivelEscolaridade"] = new SelectList(_context.NivelEscolaridade, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Models.Candidato Candidato { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Candidato.Add(Candidato);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
