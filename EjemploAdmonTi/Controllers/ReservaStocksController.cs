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
    public class ReservaStocksController : Controller
    {
        private readonly AppDbContext _context;

        public ReservaStocksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ReservaStocks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ReservaStocks.Include(r => r.Inventario).Include(r => r.Pedido).Include(r => r.Producto);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ReservaStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaStock = await _context.ReservaStocks
                .Include(r => r.Inventario)
                .Include(r => r.Pedido)
                .Include(r => r.Producto)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reservaStock == null)
            {
                return NotFound();
            }

            return View(reservaStock);
        }

        // GET: ReservaStocks/Create
        public IActionResult Create()
        {
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario");
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto");
            return View();
        }

        // POST: ReservaStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,IdPedido,IdProducto,IdInventario,CantidadReservada,FechaReserva,EstadoReserva")] ReservaStock reservaStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario", reservaStock.IdInventario);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", reservaStock.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", reservaStock.IdProducto);
            return View(reservaStock);
        }

        // GET: ReservaStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaStock = await _context.ReservaStocks.FindAsync(id);
            if (reservaStock == null)
            {
                return NotFound();
            }
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario", reservaStock.IdInventario);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", reservaStock.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", reservaStock.IdProducto);
            return View(reservaStock);
        }

        // POST: ReservaStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,IdPedido,IdProducto,IdInventario,CantidadReservada,FechaReserva,EstadoReserva")] ReservaStock reservaStock)
        {
            if (id != reservaStock.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaStockExists(reservaStock.IdReserva))
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
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario", reservaStock.IdInventario);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", reservaStock.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", reservaStock.IdProducto);
            return View(reservaStock);
        }

        // GET: ReservaStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaStock = await _context.ReservaStocks
                .Include(r => r.Inventario)
                .Include(r => r.Pedido)
                .Include(r => r.Producto)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reservaStock == null)
            {
                return NotFound();
            }

            return View(reservaStock);
        }

        // POST: ReservaStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaStock = await _context.ReservaStocks.FindAsync(id);
            if (reservaStock != null)
            {
                _context.ReservaStocks.Remove(reservaStock);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaStockExists(int id)
        {
            return _context.ReservaStocks.Any(e => e.IdReserva == id);
        }
    }
}
