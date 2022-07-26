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
    public class ServicoModelsController : Controller
    {
        private readonly AppDBContext _context;

        public ServicoModelsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: ServicoModels
        public async Task<IActionResult> Index()
        {
              return _context.Servicos != null ? 
                          View(await _context.Servicos.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Servicos'  is null.");
        }

        // GET: ServicoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servicoModel = await _context.Servicos
                .FirstOrDefaultAsync(m => m.IdServico == id);
            if (servicoModel == null)
            {
                return NotFound();
            }

            return View(servicoModel);
        }

        // GET: ServicoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServico,DataInicio,DataFinal")] ServicoModel servicoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicoModel);
        }

        // GET: ServicoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servicoModel = await _context.Servicos.FindAsync(id);
            if (servicoModel == null)
            {
                return NotFound();
            }
            return View(servicoModel);
        }

        // POST: ServicoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServico,DataInicio,DataFinal")] ServicoModel servicoModel)
        {
            if (id != servicoModel.IdServico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoModelExists(servicoModel.IdServico))
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
            return View(servicoModel);
        }

        // GET: ServicoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servicos == null)
            {
                return NotFound();
            }

            var servicoModel = await _context.Servicos
                .FirstOrDefaultAsync(m => m.IdServico == id);
            if (servicoModel == null)
            {
                return NotFound();
            }

            return View(servicoModel);
        }

        // POST: ServicoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servicos == null)
            {
                return Problem("Entity set 'AppDBContext.Servicos'  is null.");
            }
            var servicoModel = await _context.Servicos.FindAsync(id);
            if (servicoModel != null)
            {
                _context.Servicos.Remove(servicoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicoModelExists(int id)
        {
          return (_context.Servicos?.Any(e => e.IdServico == id)).GetValueOrDefault();
        }
    }
}
