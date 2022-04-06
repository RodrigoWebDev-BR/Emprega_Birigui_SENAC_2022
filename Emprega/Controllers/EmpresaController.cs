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
    public class EmpresaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpresaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empresa
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Empresa.Include(e => e.IdAreaAtuacaoNavigation).Include(e => e.IdCidadeNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Empresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .Include(e => e.IdAreaAtuacaoNavigation)
                .Include(e => e.IdCidadeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresa/Create
        public IActionResult Create()
        {
            ViewData["IdAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "Id", "Id");
            ViewData["IdCidade"] = new SelectList(_context.Cidade, "Id", "Id");
            return View();
        }

        // POST: Empresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RazaoSocial,NomeFantasia,Cnpj,Cep,Endereco,Numero,Complemento,Bairro,IdCidade,OcultarDados,Site,DataAbertura,IdAreaAtuacao")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "Id", "Id", empresa.IdAreaAtuacao);
            ViewData["IdCidade"] = new SelectList(_context.Cidade, "Id", "Id", empresa.IdCidade);
            return View(empresa);
        }

        // GET: Empresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["IdAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "Id", "Id", empresa.IdAreaAtuacao);
            ViewData["IdCidade"] = new SelectList(_context.Cidade, "Id", "Id", empresa.IdCidade);
            return View(empresa);
        }

        // POST: Empresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RazaoSocial,NomeFantasia,Cnpj,Cep,Endereco,Numero,Complemento,Bairro,IdCidade,OcultarDados,Site,DataAbertura,IdAreaAtuacao")] Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
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
            ViewData["IdAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "Id", "Id", empresa.IdAreaAtuacao);
            ViewData["IdCidade"] = new SelectList(_context.Cidade, "Id", "Id", empresa.IdCidade);
            return View(empresa);
        }

        // GET: Empresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .Include(e => e.IdAreaAtuacaoNavigation)
                .Include(e => e.IdCidadeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.Id == id);
        }
    }
}
