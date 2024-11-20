using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace ExamenGrupoTostadora.Controllers
{
    public class TipoPlantasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoPlantasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoPlantas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPlantas.ToListAsync());
        }

        // GET: TipoPlantas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPlanta = await _context.TipoPlantas
                .FirstOrDefaultAsync(m => m.TipoPlantaId == id);
            if (tipoPlanta == null)
            {
                return NotFound();
            }

            return View(tipoPlanta);
        }

        // GET: TipoPlantas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPlantas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoPlantaId,Descripcion")] TipoPlanta tipoPlanta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPlanta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPlanta);
        }

        // GET: TipoPlantas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPlanta = await _context.TipoPlantas.FindAsync(id);
            if (tipoPlanta == null)
            {
                return NotFound();
            }
            return View(tipoPlanta);
        }

        // POST: TipoPlantas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoPlantaId,Descripcion")] TipoPlanta tipoPlanta)
        {
            if (id != tipoPlanta.TipoPlantaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPlanta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPlantaExists(tipoPlanta.TipoPlantaId))
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
            return View(tipoPlanta);
        }

        // GET: TipoPlantas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPlanta = await _context.TipoPlantas
                .FirstOrDefaultAsync(m => m.TipoPlantaId == id);
            if (tipoPlanta == null)
            {
                return NotFound();
            }

            return View(tipoPlanta);
        }

        // POST: TipoPlantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPlanta = await _context.TipoPlantas.FindAsync(id);
            if (tipoPlanta != null)
            {
                _context.TipoPlantas.Remove(tipoPlanta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPlantaExists(int id)
        {
            return _context.TipoPlantas.Any(e => e.TipoPlantaId == id);
        }
    }
}
