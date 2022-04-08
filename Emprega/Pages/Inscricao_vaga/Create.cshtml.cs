#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Emprega.Models;

namespace Emprega.Pages.Inscricao_vaga
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
        ViewData["IdCandidato"] = new SelectList(_context.Candidato, "Id", "Id");
        ViewData["IdStatus"] = new SelectList(_context.InscricaoStatus, "Id", "Id");
        ViewData["IdVaga"] = new SelectList(_context.Vaga, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public InscricaoVaga InscricaoVaga { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InscricaoVaga.Add(InscricaoVaga);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
