using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EjemploAdmonTi.Models;

namespace EjemploAdmonTi.Controllers
{
    public class ReembolsoesController : Controller
    {
        private readonly AppDbContext _context;

        public ReembolsoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reembolsoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Reembolsos.Include(r => r.Devolucion);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Reembolsoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reembolso = await _context.Reembolsos
                .Include(r => r.Devolucion)
                .FirstOrDefaultAsync(m => m.IdReembolso == id);
            if (reembolso == null)
            {
                return NotFound();
            }

            return View(reembolso);
        }

        // GET: Reembolsoes/Create
        public IActionResult Create()
        {
            ViewData["IdDevolucion"] = new SelectList(_context.Devoluciones, "IdDevolucion", "IdDevolucion");
            return View();
        }

        // POST: Reembolsoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReembolso,IdDevolucion,MontoReembolso,EstadoReembolso,FechaReembolso")] Reembolso reembolso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reembolso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDevolucion"] = new SelectList(_context.Devoluciones, "IdDevolucion", "IdDevolucion", reembolso.IdDevolucion);
            return View(reembolso);
        }

        // GET: Reembolsoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reembolso = await _context.Reembolsos.FindAsync(id);
            if (reembolso == null)
            {
                return NotFound();
            }
            ViewData["IdDevolucion"] = new SelectList(_context.Devoluciones, "IdDevolucion", "IdDevolucion", reembolso.IdDevolucion);
            return View(reembolso);
        }

        // POST: Reembolsoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReembolso,IdDevolucion,MontoReembolso,EstadoReembolso,FechaReembolso")] Reembolso reembolso)
        {
            if (id != reembolso.IdReembolso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reembolso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReembolsoExists(reembolso.IdReembolso))
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
            ViewData["IdDevolucion"] = new SelectList(_context.Devoluciones, "IdDevolucion", "IdDevolucion", reembolso.IdDevolucion);
            return View(reembolso);
        }

        // GET: Reembolsoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reembolso = await _context.Reembolsos
                .Include(r => r.Devolucion)
                .FirstOrDefaultAsync(m => m.IdReembolso == id);
            if (reembolso == null)
            {
                return NotFound();
            }

            return View(reembolso);
        }

        // POST: Reembolsoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reembolso = await _context.Reembolsos.FindAsync(id);
            if (reembolso != null)
            {
                _context.Reembolsos.Remove(reembolso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReembolsoExists(int id)
        {
            return _context.Reembolsos.Any(e => e.IdReembolso == id);
        }
    }
}
