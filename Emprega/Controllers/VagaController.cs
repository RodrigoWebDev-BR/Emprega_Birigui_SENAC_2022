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
    public class VagaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VagaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vaga
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vaga.Include(v => v.IdAreaAtuacaoNavigation).Include(v => v.IdEmpresaNavigation).Include(v => v.IdTipoContratoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vaga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vaga
                .Include(v => v.IdAreaAtuacaoNavigation)
                .Include(v => v.IdEmpresaNavigation)
                .Include(v => v.IdTipoContratoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // GET: Vaga/Create
        public IActionResult Create()
        {
            ViewData["IdAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "Id", "Id");
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "Id");
            ViewData["IdTipoContrato"] = new SelectList(_context.TipoContrato, "Id", "Id");
            return View();
        }

        // POST: Vaga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEmpresa,Titulo,Salario,Pcd,DataPublicacao,Requisitos,PrincipaisAtividades,Descricao,Quantidade,QuantidadeDisponivel,Situacao,TempoContrato,IdAreaAtuacao,IdTipoContrato")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "Id", "Id", vaga.IdAreaAtuacao);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "Id", vaga.IdEmpresa);
            ViewData["IdTipoContrato"] = new SelectList(_context.TipoContrato, "Id", "Id", vaga.IdTipoContrato);
            return View(vaga);
        }

        // GET: Vaga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vaga.FindAsync(id);
            if (vaga == null)
            {
                return NotFound();
            }
            ViewData["IdAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "Id", "Id", vaga.IdAreaAtuacao);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "Id", vaga.IdEmpresa);
            ViewData["IdTipoContrato"] = new SelectList(_context.TipoContrato, "Id", "Id", vaga.IdTipoContrato);
            return View(vaga);
        }

        // POST: Vaga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEmpresa,Titulo,Salario,Pcd,DataPublicacao,Requisitos,PrincipaisAtividades,Descricao,Quantidade,QuantidadeDisponivel,Situacao,TempoContrato,IdAreaAtuacao,IdTipoContrato")] Vaga vaga)
        {
            if (id != vaga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagaExists(vaga.Id))
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
            ViewData["IdAreaAtuacao"] = new SelectList(_context.AreaAtuacao, "Id", "Id", vaga.IdAreaAtuacao);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresa, "Id", "Id", vaga.IdEmpresa);
            ViewData["IdTipoContrato"] = new SelectList(_context.TipoContrato, "Id", "Id", vaga.IdTipoContrato);
            return View(vaga);
        }

        // GET: Vaga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vaga
                .Include(v => v.IdAreaAtuacaoNavigation)
                .Include(v => v.IdEmpresaNavigation)
                .Include(v => v.IdTipoContratoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // POST: Vaga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaga = await _context.Vaga.FindAsync(id);
            _context.Vaga.Remove(vaga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagaExists(int id)
        {
            return _context.Vaga.Any(e => e.Id == id);
        }
    }
}
