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
    public class SLAsController : Controller
    {
        private readonly AppDbContext _context;

        public SLAsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SLAs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SLAs.Include(s => s.ContratoServicio);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SLAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sLA = await _context.SLAs
                .Include(s => s.ContratoServicio)
                .FirstOrDefaultAsync(m => m.IdSLA == id);
            if (sLA == null)
            {
                return NotFound();
            }

            return View(sLA);
        }

        // GET: SLAs/Create
        public IActionResult Create()
        {
            ViewData["IdContrato"] = new SelectList(_context.ContratosServicios, "IdContrato", "IdContrato");
            return View();
        }

        // POST: SLAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSLA,IdContrato,Prioridad,TiempoRespuesta,TiempoResolucion,Descripcion")] SLA sLA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sLA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdContrato"] = new SelectList(_context.ContratosServicios, "IdContrato", "IdContrato", sLA.IdContrato);
            return View(sLA);
        }

        // GET: SLAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sLA = await _context.SLAs.FindAsync(id);
            if (sLA == null)
            {
                return NotFound();
            }
            ViewData["IdContrato"] = new SelectList(_context.ContratosServicios, "IdContrato", "IdContrato", sLA.IdContrato);
            return View(sLA);
        }

        // POST: SLAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSLA,IdContrato,Prioridad,TiempoRespuesta,TiempoResolucion,Descripcion")] SLA sLA)
        {
            if (id != sLA.IdSLA)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sLA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SLAExists(sLA.IdSLA))
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
            ViewData["IdContrato"] = new SelectList(_context.ContratosServicios, "IdContrato", "IdContrato", sLA.IdContrato);
            return View(sLA);
        }

        // GET: SLAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sLA = await _context.SLAs
                .Include(s => s.ContratoServicio)
                .FirstOrDefaultAsync(m => m.IdSLA == id);
            if (sLA == null)
            {
                return NotFound();
            }

            return View(sLA);
        }

        // POST: SLAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sLA = await _context.SLAs.FindAsync(id);
            if (sLA != null)
            {
                _context.SLAs.Remove(sLA);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SLAExists(int id)
        {
            return _context.SLAs.Any(e => e.IdSLA == id);
        }
    }
}
