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
    public class ContratoServiciosController : Controller
    {
        private readonly AppDbContext _context;

        public ContratoServiciosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContratoServicios
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ContratosServicios.Include(c => c.ProveedorTecnologico);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ContratoServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoServicio = await _context.ContratosServicios
                .Include(c => c.ProveedorTecnologico)
                .FirstOrDefaultAsync(m => m.IdContrato == id);
            if (contratoServicio == null)
            {
                return NotFound();
            }

            return View(contratoServicio);
        }

        // GET: ContratoServicios/Create
        public IActionResult Create()
        {
            ViewData["IdProveedor"] = new SelectList(_context.ProveedoresTecnologicos, "IdProveedor", "IdProveedor");
            return View();
        }

        // POST: ContratoServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContrato,IdProveedor,FechaInicio,FechaFin,MontoImplementacion,MontoMensual,EstadoContrato")] ContratoServicio contratoServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProveedor"] = new SelectList(_context.ProveedoresTecnologicos, "IdProveedor", "IdProveedor", contratoServicio.IdProveedor);
            return View(contratoServicio);
        }

        // GET: ContratoServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoServicio = await _context.ContratosServicios.FindAsync(id);
            if (contratoServicio == null)
            {
                return NotFound();
            }
            ViewData["IdProveedor"] = new SelectList(_context.ProveedoresTecnologicos, "IdProveedor", "IdProveedor", contratoServicio.IdProveedor);
            return View(contratoServicio);
        }

        // POST: ContratoServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContrato,IdProveedor,FechaInicio,FechaFin,MontoImplementacion,MontoMensual,EstadoContrato")] ContratoServicio contratoServicio)
        {
            if (id != contratoServicio.IdContrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoServicioExists(contratoServicio.IdContrato))
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
            ViewData["IdProveedor"] = new SelectList(_context.ProveedoresTecnologicos, "IdProveedor", "IdProveedor", contratoServicio.IdProveedor);
            return View(contratoServicio);
        }

        // GET: ContratoServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoServicio = await _context.ContratosServicios
                .Include(c => c.ProveedorTecnologico)
                .FirstOrDefaultAsync(m => m.IdContrato == id);
            if (contratoServicio == null)
            {
                return NotFound();
            }

            return View(contratoServicio);
        }

        // POST: ContratoServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratoServicio = await _context.ContratosServicios.FindAsync(id);
            if (contratoServicio != null)
            {
                _context.ContratosServicios.Remove(contratoServicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoServicioExists(int id)
        {
            return _context.ContratosServicios.Any(e => e.IdContrato == id);
        }
    }
}
