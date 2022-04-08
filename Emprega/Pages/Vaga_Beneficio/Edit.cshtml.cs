#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Pages.Vaga_Beneficio
{
    public class EditModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public EditModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VagaBeneficio VagaBeneficio { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VagaBeneficio = await _context.VagaBeneficio
                .Include(v => v.IdBeneficioNavigation)
                .Include(v => v.IdVagaNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (VagaBeneficio == null)
            {
                return NotFound();
            }
           ViewData["IdBeneficio"] = new SelectList(_context.Beneficio, "Id", "Id");
           ViewData["IdVaga"] = new SelectList(_context.Vaga, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VagaBeneficio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagaBeneficioExists(VagaBeneficio.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VagaBeneficioExists(int id)
        {
            return _context.VagaBeneficio.Any(e => e.Id == id);
        }
    }
}
