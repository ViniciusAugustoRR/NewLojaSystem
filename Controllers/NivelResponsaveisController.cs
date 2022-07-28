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
    public class NivelResponsaveisController : Controller
    {
        private readonly AppDBContext _context;

        public NivelResponsaveisController(AppDBContext context)
        {
            _context = context;
        }

        // GET: NivelResponsaveis
        public async Task<IActionResult> Index()
        {
              return _context.Responsaveis != null ? 
                          View(await _context.Responsaveis.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Responsaveis'  is null.");
        }

        // GET: NivelResponsaveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var nivelResponsavel = await _context.Responsaveis
                .FirstOrDefaultAsync(m => m.IdNivel == id);
            if (nivelResponsavel == null)
            {
                return NotFound();
            }

            return View(nivelResponsavel);
        }

        // GET: NivelResponsaveis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelResponsaveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNivel,Nivel")] NivelResponsavel nivelResponsavel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelResponsavel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelResponsavel);
        }

        // GET: NivelResponsaveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var nivelResponsavel = await _context.Responsaveis.FindAsync(id);
            if (nivelResponsavel == null)
            {
                return NotFound();
            }
            return View(nivelResponsavel);
        }

        // POST: NivelResponsaveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNivel,Nivel")] NivelResponsavel nivelResponsavel)
        {
            if (id != nivelResponsavel.IdNivel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelResponsavel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelResponsavelExists(nivelResponsavel.IdNivel))
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
            return View(nivelResponsavel);
        }

        // GET: NivelResponsaveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var nivelResponsavel = await _context.Responsaveis
                .FirstOrDefaultAsync(m => m.IdNivel == id);
            if (nivelResponsavel == null)
            {
                return NotFound();
            }

            return View(nivelResponsavel);
        }

        // POST: NivelResponsaveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Responsaveis == null)
            {
                return Problem("Entity set 'AppDBContext.Responsaveis'  is null.");
            }
            var nivelResponsavel = await _context.Responsaveis.FindAsync(id);
            if (nivelResponsavel != null)
            {
                _context.Responsaveis.Remove(nivelResponsavel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelResponsavelExists(int id)
        {
          return (_context.Responsaveis?.Any(e => e.IdNivel == id)).GetValueOrDefault();
        }
    }
}
