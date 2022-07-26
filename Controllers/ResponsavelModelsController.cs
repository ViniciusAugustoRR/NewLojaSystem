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
    public class ResponsavelModelsController : Controller
    {
        private readonly AppDBContext _context;

        public ResponsavelModelsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: ResponsavelModels
        public async Task<IActionResult> Index()
        {
              return _context.Responsaveis != null ? 
                          View(await _context.Responsaveis.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Responsaveis'  is null.");
        }

        // GET: ResponsavelModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var responsavelModel = await _context.Responsaveis
                .FirstOrDefaultAsync(m => m.IdResponsavel == id);
            if (responsavelModel == null)
            {
                return NotFound();
            }

            return View(responsavelModel);
        }

        // GET: ResponsavelModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResponsavelModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResponsavel,NameResponsavel,CategoriaResponsavel")] ResponsavelModel responsavelModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsavelModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsavelModel);
        }

        // GET: ResponsavelModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var responsavelModel = await _context.Responsaveis.FindAsync(id);
            if (responsavelModel == null)
            {
                return NotFound();
            }
            return View(responsavelModel);
        }

        // POST: ResponsavelModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResponsavel,NameResponsavel,CategoriaResponsavel")] ResponsavelModel responsavelModel)
        {
            if (id != responsavelModel.IdResponsavel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsavelModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsavelModelExists(responsavelModel.IdResponsavel))
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
            return View(responsavelModel);
        }

        // GET: ResponsavelModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var responsavelModel = await _context.Responsaveis
                .FirstOrDefaultAsync(m => m.IdResponsavel == id);
            if (responsavelModel == null)
            {
                return NotFound();
            }

            return View(responsavelModel);
        }

        // POST: ResponsavelModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Responsaveis == null)
            {
                return Problem("Entity set 'AppDBContext.Responsaveis'  is null.");
            }
            var responsavelModel = await _context.Responsaveis.FindAsync(id);
            if (responsavelModel != null)
            {
                _context.Responsaveis.Remove(responsavelModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsavelModelExists(int id)
        {
          return (_context.Responsaveis?.Any(e => e.IdResponsavel == id)).GetValueOrDefault();
        }
    }
}
