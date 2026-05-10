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
    public class CanalVentasController : Controller
    {
        private readonly AppDbContext _context;

        public CanalVentasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CanalVentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CanalVentas.ToListAsync());
        }

        // GET: CanalVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canalVenta = await _context.CanalVentas
                .FirstOrDefaultAsync(m => m.IdCanal == id);
            if (canalVenta == null)
            {
                return NotFound();
            }

            return View(canalVenta);
        }

        // GET: CanalVentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CanalVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCanal,NombreCanal,Descripcion")] CanalVenta canalVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canalVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(canalVenta);
        }

        // GET: CanalVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canalVenta = await _context.CanalVentas.FindAsync(id);
            if (canalVenta == null)
            {
                return NotFound();
            }
            return View(canalVenta);
        }

        // POST: CanalVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCanal,NombreCanal,Descripcion")] CanalVenta canalVenta)
        {
            if (id != canalVenta.IdCanal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canalVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanalVentaExists(canalVenta.IdCanal))
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
            return View(canalVenta);
        }

        // GET: CanalVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canalVenta = await _context.CanalVentas
                .FirstOrDefaultAsync(m => m.IdCanal == id);
            if (canalVenta == null)
            {
                return NotFound();
            }

            return View(canalVenta);
        }

        // POST: CanalVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var canalVenta = await _context.CanalVentas.FindAsync(id);
            if (canalVenta != null)
            {
                _context.CanalVentas.Remove(canalVenta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanalVentaExists(int id)
        {
            return _context.CanalVentas.Any(e => e.IdCanal == id);
        }
    }
}
