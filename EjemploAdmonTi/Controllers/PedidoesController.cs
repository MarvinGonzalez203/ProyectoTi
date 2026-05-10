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
    public class PedidoesController : Controller
    {
        private readonly AppDbContext _context;

        public PedidoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Pedidos.Include(p => p.CanalVenta).Include(p => p.Cliente).Include(p => p.Tienda);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.CanalVenta)
                .Include(p => p.Cliente)
                .Include(p => p.Tienda)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            ViewData["IdCanal"] = new SelectList(_context.CanalVentas, "IdCanal", "IdCanal");
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "IdTienda");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,IdCliente,IdCanal,IdTienda,FechaPedido,EstadoPedido,TotalPedido")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanal"] = new SelectList(_context.CanalVentas, "IdCanal", "IdCanal", pedido.IdCanal);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", pedido.IdCliente);
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "IdTienda", pedido.IdTienda);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["IdCanal"] = new SelectList(_context.CanalVentas, "IdCanal", "IdCanal", pedido.IdCanal);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", pedido.IdCliente);
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "IdTienda", pedido.IdTienda);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,IdCliente,IdCanal,IdTienda,FechaPedido,EstadoPedido,TotalPedido")] Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.IdPedido))
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
            ViewData["IdCanal"] = new SelectList(_context.CanalVentas, "IdCanal", "IdCanal", pedido.IdCanal);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", pedido.IdCliente);
            ViewData["IdTienda"] = new SelectList(_context.Tiendas, "IdTienda", "IdTienda", pedido.IdTienda);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.CanalVenta)
                .Include(p => p.Cliente)
                .Include(p => p.Tienda)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.IdPedido == id);
        }
    }
}
