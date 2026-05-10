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
    public class TicketSoportesController : Controller
    {
        private readonly AppDbContext _context;

        public TicketSoportesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TicketSoportes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TicketSoportes.Include(t => t.Cliente).Include(t => t.Pedido).Include(t => t.SLA);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TicketSoportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketSoporte = await _context.TicketSoportes
                .Include(t => t.Cliente)
                .Include(t => t.Pedido)
                .Include(t => t.SLA)
                .FirstOrDefaultAsync(m => m.IdTicket == id);
            if (ticketSoporte == null)
            {
                return NotFound();
            }

            return View(ticketSoporte);
        }

        // GET: TicketSoportes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido");
            ViewData["IdSLA"] = new SelectList(_context.SLAs, "IdSLA", "IdSLA");
            return View();
        }

        // POST: TicketSoportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTicket,IdCliente,IdPedido,IdSLA,Asunto,Descripcion,Prioridad,EstadoTicket,FechaCreacion")] TicketSoporte ticketSoporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketSoporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ticketSoporte.IdCliente);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", ticketSoporte.IdPedido);
            ViewData["IdSLA"] = new SelectList(_context.SLAs, "IdSLA", "IdSLA", ticketSoporte.IdSLA);
            return View(ticketSoporte);
        }

        // GET: TicketSoportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketSoporte = await _context.TicketSoportes.FindAsync(id);
            if (ticketSoporte == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ticketSoporte.IdCliente);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", ticketSoporte.IdPedido);
            ViewData["IdSLA"] = new SelectList(_context.SLAs, "IdSLA", "IdSLA", ticketSoporte.IdSLA);
            return View(ticketSoporte);
        }

        // POST: TicketSoportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTicket,IdCliente,IdPedido,IdSLA,Asunto,Descripcion,Prioridad,EstadoTicket,FechaCreacion")] TicketSoporte ticketSoporte)
        {
            if (id != ticketSoporte.IdTicket)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketSoporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketSoporteExists(ticketSoporte.IdTicket))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ticketSoporte.IdCliente);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", ticketSoporte.IdPedido);
            ViewData["IdSLA"] = new SelectList(_context.SLAs, "IdSLA", "IdSLA", ticketSoporte.IdSLA);
            return View(ticketSoporte);
        }

        // GET: TicketSoportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketSoporte = await _context.TicketSoportes
                .Include(t => t.Cliente)
                .Include(t => t.Pedido)
                .Include(t => t.SLA)
                .FirstOrDefaultAsync(m => m.IdTicket == id);
            if (ticketSoporte == null)
            {
                return NotFound();
            }

            return View(ticketSoporte);
        }

        // POST: TicketSoportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketSoporte = await _context.TicketSoportes.FindAsync(id);
            if (ticketSoporte != null)
            {
                _context.TicketSoportes.Remove(ticketSoporte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketSoporteExists(int id)
        {
            return _context.TicketSoportes.Any(e => e.IdTicket == id);
        }
    }
}
