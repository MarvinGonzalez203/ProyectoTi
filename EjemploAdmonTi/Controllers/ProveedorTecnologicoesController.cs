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
    public class ProveedorTecnologicoesController : Controller
    {
        private readonly AppDbContext _context;

        public ProveedorTecnologicoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProveedorTecnologicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProveedoresTecnologicos.ToListAsync());
        }

        // GET: ProveedorTecnologicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedorTecnologico = await _context.ProveedoresTecnologicos
                .FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (proveedorTecnologico == null)
            {
                return NotFound();
            }

            return View(proveedorTecnologico);
        }

        // GET: ProveedorTecnologicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProveedorTecnologicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProveedor,NombreProveedor,ServicioProveedor,CorreoContacto,Telefono")] ProveedorTecnologico proveedorTecnologico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedorTecnologico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedorTecnologico);
        }

        // GET: ProveedorTecnologicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedorTecnologico = await _context.ProveedoresTecnologicos.FindAsync(id);
            if (proveedorTecnologico == null)
            {
                return NotFound();
            }
            return View(proveedorTecnologico);
        }

        // POST: ProveedorTecnologicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProveedor,NombreProveedor,ServicioProveedor,CorreoContacto,Telefono")] ProveedorTecnologico proveedorTecnologico)
        {
            if (id != proveedorTecnologico.IdProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedorTecnologico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorTecnologicoExists(proveedorTecnologico.IdProveedor))
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
            return View(proveedorTecnologico);
        }

        // GET: ProveedorTecnologicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedorTecnologico = await _context.ProveedoresTecnologicos
                .FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (proveedorTecnologico == null)
            {
                return NotFound();
            }

            return View(proveedorTecnologico);
        }

        // POST: ProveedorTecnologicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedorTecnologico = await _context.ProveedoresTecnologicos.FindAsync(id);
            if (proveedorTecnologico != null)
            {
                _context.ProveedoresTecnologicos.Remove(proveedorTecnologico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedorTecnologicoExists(int id)
        {
            return _context.ProveedoresTecnologicos.Any(e => e.IdProveedor == id);
        }
    }
}
