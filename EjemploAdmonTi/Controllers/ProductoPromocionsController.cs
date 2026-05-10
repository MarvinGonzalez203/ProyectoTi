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
    public class ProductoPromocionsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductoPromocionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductoPromocions
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProductoPromociones.Include(p => p.Producto).Include(p => p.Promocion);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProductoPromocions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoPromocion = await _context.ProductoPromociones
                .Include(p => p.Producto)
                .Include(p => p.Promocion)
                .FirstOrDefaultAsync(m => m.IdProductoPromocion == id);
            if (productoPromocion == null)
            {
                return NotFound();
            }

            return View(productoPromocion);
        }

        // GET: ProductoPromocions/Create
        public IActionResult Create()
        {
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto");
            ViewData["IdPromocion"] = new SelectList(_context.Promociones, "IdPromocion", "IdPromocion");
            return View();
        }

        // POST: ProductoPromocions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProductoPromocion,IdProducto,IdPromocion")] ProductoPromocion productoPromocion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoPromocion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", productoPromocion.IdProducto);
            ViewData["IdPromocion"] = new SelectList(_context.Promociones, "IdPromocion", "IdPromocion", productoPromocion.IdPromocion);
            return View(productoPromocion);
        }

        // GET: ProductoPromocions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoPromocion = await _context.ProductoPromociones.FindAsync(id);
            if (productoPromocion == null)
            {
                return NotFound();
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", productoPromocion.IdProducto);
            ViewData["IdPromocion"] = new SelectList(_context.Promociones, "IdPromocion", "IdPromocion", productoPromocion.IdPromocion);
            return View(productoPromocion);
        }

        // POST: ProductoPromocions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProductoPromocion,IdProducto,IdPromocion")] ProductoPromocion productoPromocion)
        {
            if (id != productoPromocion.IdProductoPromocion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoPromocion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoPromocionExists(productoPromocion.IdProductoPromocion))
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
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", productoPromocion.IdProducto);
            ViewData["IdPromocion"] = new SelectList(_context.Promociones, "IdPromocion", "IdPromocion", productoPromocion.IdPromocion);
            return View(productoPromocion);
        }

        // GET: ProductoPromocions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoPromocion = await _context.ProductoPromociones
                .Include(p => p.Producto)
                .Include(p => p.Promocion)
                .FirstOrDefaultAsync(m => m.IdProductoPromocion == id);
            if (productoPromocion == null)
            {
                return NotFound();
            }

            return View(productoPromocion);
        }

        // POST: ProductoPromocions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoPromocion = await _context.ProductoPromociones.FindAsync(id);
            if (productoPromocion != null)
            {
                _context.ProductoPromociones.Remove(productoPromocion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoPromocionExists(int id)
        {
            return _context.ProductoPromociones.Any(e => e.IdProductoPromocion == id);
        }
    }
}
