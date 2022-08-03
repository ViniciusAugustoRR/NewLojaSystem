using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaSystem.DB;
using LojaSystem.Models;

namespace LojaSystem.Controllers
{
    public class ResponsaveisController : Controller
    {
        private readonly AppDBContext _context;

        public ResponsaveisController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Responsaveis
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Responsaveis.Include(r => r.NivelResponsavel);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Responsaveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsaveis
                .Include(r => r.NivelResponsavel)
                .FirstOrDefaultAsync(m => m.IdResponsavel == id);
            if (responsavel == null)
            {
                return NotFound();
            }

            return View(responsavel);
        }

        // GET: Responsaveis/Create
        public IActionResult Create()
        {
            ViewData["NivelResponsavelId"] = new SelectList(_context.NivelResponsaveis, "IdNivel", "Nivel");
            return View();
        }

        // POST: Responsaveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResponsavel,Nome,Email,Login,Senha,NivelResponsavelId")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsavel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NivelResponsavelId"] = new SelectList(_context.NivelResponsaveis, "IdNivel", "Nivel", responsavel.NivelResponsavelId);
            return View(responsavel);
        }

        // GET: Responsaveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsaveis.FindAsync(id);
            if (responsavel == null)
            {
                return NotFound();
            }
            ViewData["NivelResponsavelId"] = new SelectList(_context.NivelResponsaveis, "IdNivel", "Nivel", responsavel.NivelResponsavelId);
            return View(responsavel);
        }

        // POST: Responsaveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResponsavel,Nome,Email,Login,Senha,NivelResponsavelId")] Responsavel responsavel)
        {
            if (id != responsavel.IdResponsavel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsavel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsavelExists(responsavel.IdResponsavel))
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
            ViewData["NivelResponsavelId"] = new SelectList(_context.NivelResponsaveis, "IdNivel", "IdNivel", responsavel.NivelResponsavelId);
            return View(responsavel);
        }

        // GET: Responsaveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsaveis
                .Include(r => r.NivelResponsavel)
                .FirstOrDefaultAsync(m => m.IdResponsavel == id);
            if (responsavel == null)
            {
                return NotFound();
            }

            return View(responsavel);
        }

        // POST: Responsaveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Responsaveis == null)
            {
                return Problem("Entity set 'AppDBContext.Responsaveis'  is null.");
            }
            var responsavel = await _context.Responsaveis.FindAsync(id);
            if (responsavel != null)
            {
                _context.Responsaveis.Remove(responsavel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsavelExists(int id)
        {
          return (_context.Responsaveis?.Any(e => e.IdResponsavel == id)).GetValueOrDefault();
        }
    }
}
