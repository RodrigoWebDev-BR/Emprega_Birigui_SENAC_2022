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

namespace Emprega.Pages.Beneficio
{
    public class EditModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public EditModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Beneficio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficioExists(Beneficio.Id))
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

        private bool BeneficioExists(int id)
        {
            return _context.Beneficio.Any(e => e.Id == id);
        }
    }
}
