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
    public class ServicosController : Controller
    {
        private readonly AppDBContext _context;

        public ServicosController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Servicos
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Servico.Include(s => s.ClienteServico).Include(s => s.EquipamentoServico).Include(s => s.ResponsavelServico);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Servicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servico == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico
                .Include(s => s.ClienteServico)
                .Include(s => s.EquipamentoServico)
                .Include(s => s.ResponsavelServico)
                .FirstOrDefaultAsync(m => m.IdServico == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // GET: Servicos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "IdCliente", "Nome");
            ViewData["EquipamentoServicoId"] = new SelectList(_context.Equipamentos, "IdEquipamento", "Nome");
            ViewData["ResponsavelServicoId"] = new SelectList(_context.Responsaveis, "IdResponsavel", "Nome");
            return View();
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServico,DataInicio,DataFinal,ClienteId,EquipamentoServicoId,ResponsavelServicoId")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "IdCliente", "Nome", servico.ClienteId);
            ViewData["EquipamentoServicoId"] = new SelectList(_context.Equipamentos, "IdEquipamento", "Nome", servico.EquipamentoServicoId);
            ViewData["ResponsavelServicoId"] = new SelectList(_context.Responsaveis, "IdResponsavel", "Nome", servico.ResponsavelServicoId);
            return View(servico);
        }

        // GET: Servicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servico == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "IdCliente", "Nome", servico.ClienteId);
            ViewData["EquipamentoServicoId"] = new SelectList(_context.Equipamentos, "IdEquipamento", "Nome", servico.EquipamentoServicoId);
            ViewData["ResponsavelServicoId"] = new SelectList(_context.Responsaveis, "IdResponsavel", "Nome", servico.ResponsavelServicoId);
            return View(servico);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServico,DataInicio,DataFinal,ClienteId,EquipamentoServicoId,ResponsavelServicoId")] Servico servico)
        {
            if (id != servico.IdServico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.IdServico))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "IdCliente", "Nome", servico.ClienteId);
            ViewData["EquipamentoServicoId"] = new SelectList(_context.Equipamentos, "IdEquipamento", "Nome", servico.EquipamentoServicoId);
            ViewData["ResponsavelServicoId"] = new SelectList(_context.Responsaveis, "IdResponsavel", "Nome", servico.ResponsavelServicoId);
            return View(servico);
        }

        // GET: Servicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servico == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico
                .Include(s => s.ClienteServico)
                .Include(s => s.EquipamentoServico)
                .Include(s => s.ResponsavelServico)
                .FirstOrDefaultAsync(m => m.IdServico == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servico == null)
            {
                return Problem("Entity set 'AppDBContext.Servico'  is null.");
            }
            var servico = await _context.Servico.FindAsync(id);
            if (servico != null)
            {
                _context.Servico.Remove(servico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicoExists(int id)
        {
          return (_context.Servico?.Any(e => e.IdServico == id)).GetValueOrDefault();
        }
    }
}
