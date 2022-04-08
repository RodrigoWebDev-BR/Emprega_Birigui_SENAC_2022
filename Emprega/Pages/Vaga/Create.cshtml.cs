#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Emprega.Models;

namespace Emprega.Pages.Vaga
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
        ViewData["IdAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "Id", "Nome");
        ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "NomeFantasia");
        ViewData["IdTipoContrato"] = new SelectList(_context.TipoContrato, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public Models.Vaga Vaga { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vaga.Add(Vaga);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
