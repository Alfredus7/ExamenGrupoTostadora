using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using ExamenGrupoTostadora.ViewModel;

namespace ExamenGrupoTostadora.Controllers
{
    public class PlantasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plantas
        public async Task<IActionResult> Index()
        {
            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();

            var modelList = webApiClient.GetPlantas<List<Plantasviewmodel>>();

            return View(modelList.Data);
        }

        // GET: Plantas/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
            var Views = webApiClient.GetPlantaById<Plantasviewmodel>(id.Value);


            if (Views.Data == null)
            {
                return NotFound();
            }


            return View(Views.Data);
        }

        // GET: Plantas/Create
        public IActionResult Create()
        {
            ViewData["TipoPlantaId"] = new SelectList(_context.TipoPlantas, "TipoPlantaId", "Descripcion");
            return View();
        }

        // POST: Plantas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,TipoPlantaId")] Plantasviewmodel planta)
        {
            if (ModelState.IsValid)
            {

                WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
                var Views = webApiClient.PostPlanta<Plantasviewmodel>(planta);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoPlantaId"] = new SelectList(_context.TipoPlantas, "TipoPlantaId", "Descripcion", planta.TipoPlantaId);
            return View(planta);
        }

        // GET: Plantas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
            var Views = webApiClient.GetPlantaById<Plantasviewmodel>(id.Value);
            ViewData["TipoPlantaId"] = new SelectList(_context.TipoPlantas, "TipoPlantaId", "Descripcion", Views.Data.TipoPlantaId);
            
            if (Views.Data == null)
            {
                return NotFound();
            }

            return View(Views.Data);
        }

        // POST: Plantas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,TipoPlantaId")] Plantasviewmodel planta)
        {
            if (ModelState.IsValid)
            {
                WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
                var Views = webApiClient.PutPlanta<Plantasviewmodel, Planta>(id, planta);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoPlantaId"] = new SelectList(_context.TipoPlantas, "TipoPlantaId", "Descripcion", planta.TipoPlantaId);
            return View(planta);
        }

        // GET: Plantas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
            var Views = webApiClient.GetPlantaById<Plantasviewmodel>(id.Value);

            if (Views.Data == null)
            {
                return NotFound();
            }
            return View(Views.Data);
        }

        // POST: Plantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
            var Views = webApiClient.DeletePlantaById<Plantasviewmodel>(id);
            if (Views.Data == false)
            {
                BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PlantaExists(int id)
        {
            return _context.Plantas.Any(e => e.Id == id);
        }
    }
}
