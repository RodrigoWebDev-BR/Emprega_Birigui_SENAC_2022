#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Controllers
{
    public class IdiomaCandidatoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdiomaCandidatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IdiomaCandidato
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IdiomaCandidato.Include(i => i.IdIdiomaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IdiomaCandidato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomaCandidato = await _context.IdiomaCandidato
                .Include(i => i.IdIdiomaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idiomaCandidato == null)
            {
                return NotFound();
            }

            return View(idiomaCandidato);
        }

        // GET: IdiomaCandidato/Create
        public IActionResult Create()
        {
            ViewData["IdIdioma"] = new SelectList(_context.Idioma, "Id", "Id");
            return View();
        }

        // POST: IdiomaCandidato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdIdioma,Nivel")] IdiomaCandidato idiomaCandidato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(idiomaCandidato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdIdioma"] = new SelectList(_context.Idioma, "Id", "Id", idiomaCandidato.IdIdioma);
            return View(idiomaCandidato);
        }

        // GET: IdiomaCandidato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomaCandidato = await _context.IdiomaCandidato.FindAsync(id);
            if (idiomaCandidato == null)
            {
                return NotFound();
            }
            ViewData["IdIdioma"] = new SelectList(_context.Idioma, "Id", "Id", idiomaCandidato.IdIdioma);
            return View(idiomaCandidato);
        }

        // POST: IdiomaCandidato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdIdioma,Nivel")] IdiomaCandidato idiomaCandidato)
        {
            if (id != idiomaCandidato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idiomaCandidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdiomaCandidatoExists(idiomaCandidato.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdIdioma"] = new SelectList(_context.Idioma, "Id", "Id", idiomaCandidato.IdIdioma);
            return View(idiomaCandidato);
        }

        // GET: IdiomaCandidato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomaCandidato = await _context.IdiomaCandidato
                .Include(i => i.IdIdiomaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idiomaCandidato == null)
            {
                return NotFound();
            }

            return View(idiomaCandidato);
        }

        // POST: IdiomaCandidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var idiomaCandidato = await _context.IdiomaCandidato.FindAsync(id);
            _context.IdiomaCandidato.Remove(idiomaCandidato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdiomaCandidatoExists(int id)
        {
            return _context.IdiomaCandidato.Any(e => e.Id == id);
        }
    }
}
