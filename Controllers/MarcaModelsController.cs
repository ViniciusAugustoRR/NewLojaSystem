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
    public class MarcaModelsController : Controller
    {
        private readonly AppDBContext _context;

        public MarcaModelsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: MarcaModels
        public async Task<IActionResult> Index()
        {
              return _context.Marcas != null ? 
                          View(await _context.Marcas.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Marcas'  is null.");
        }

        // GET: MarcaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Marcas == null)
            {
                return NotFound();
            }

            var marcaModel = await _context.Marcas
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (marcaModel == null)
            {
                return NotFound();
            }

            return View(marcaModel);
        }

        // GET: MarcaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarca,NomeMarca")] MarcaModel marcaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaModel);
        }

        // GET: MarcaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Marcas == null)
            {
                return NotFound();
            }

            var marcaModel = await _context.Marcas.FindAsync(id);
            if (marcaModel == null)
            {
                return NotFound();
            }
            return View(marcaModel);
        }

        // POST: MarcaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarca,NomeMarca")] MarcaModel marcaModel)
        {
            if (id != marcaModel.IdMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaModelExists(marcaModel.IdMarca))
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
            return View(marcaModel);
        }

        // GET: MarcaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Marcas == null)
            {
                return NotFound();
            }

            var marcaModel = await _context.Marcas
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (marcaModel == null)
            {
                return NotFound();
            }

            return View(marcaModel);
        }

        // POST: MarcaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Marcas == null)
            {
                return Problem("Entity set 'AppDBContext.Marcas'  is null.");
            }
            var marcaModel = await _context.Marcas.FindAsync(id);
            if (marcaModel != null)
            {
                _context.Marcas.Remove(marcaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaModelExists(int id)
        {
          return (_context.Marcas?.Any(e => e.IdMarca == id)).GetValueOrDefault();
        }
    }
}
