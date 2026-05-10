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
    public class MovimientoInventariosController : Controller
    {
        private readonly AppDbContext _context;

        public MovimientoInventariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MovimientoInventarios
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MovimientoInventarios.Include(m => m.Inventario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MovimientoInventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoInventario = await _context.MovimientoInventarios
                .Include(m => m.Inventario)
                .FirstOrDefaultAsync(m => m.IdMovimiento == id);
            if (movimientoInventario == null)
            {
                return NotFound();
            }

            return View(movimientoInventario);
        }

        // GET: MovimientoInventarios/Create
        public IActionResult Create()
        {
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario");
            return View();
        }

        // POST: MovimientoInventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMovimiento,IdInventario,TipoMovimiento,Cantidad,Motivo,FechaMovimiento")] MovimientoInventario movimientoInventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientoInventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario", movimientoInventario.IdInventario);
            return View(movimientoInventario);
        }

        // GET: MovimientoInventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoInventario = await _context.MovimientoInventarios.FindAsync(id);
            if (movimientoInventario == null)
            {
                return NotFound();
            }
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario", movimientoInventario.IdInventario);
            return View(movimientoInventario);
        }

        // POST: MovimientoInventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMovimiento,IdInventario,TipoMovimiento,Cantidad,Motivo,FechaMovimiento")] MovimientoInventario movimientoInventario)
        {
            if (id != movimientoInventario.IdMovimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientoInventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoInventarioExists(movimientoInventario.IdMovimiento))
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
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario", movimientoInventario.IdInventario);
            return View(movimientoInventario);
        }

        // GET: MovimientoInventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoInventario = await _context.MovimientoInventarios
                .Include(m => m.Inventario)
                .FirstOrDefaultAsync(m => m.IdMovimiento == id);
            if (movimientoInventario == null)
            {
                return NotFound();
            }

            return View(movimientoInventario);
        }

        // POST: MovimientoInventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimientoInventario = await _context.MovimientoInventarios.FindAsync(id);
            if (movimientoInventario != null)
            {
                _context.MovimientoInventarios.Remove(movimientoInventario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoInventarioExists(int id)
        {
            return _context.MovimientoInventarios.Any(e => e.IdMovimiento == id);
        }
    }
}
