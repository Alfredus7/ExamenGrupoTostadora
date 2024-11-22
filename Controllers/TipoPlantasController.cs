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
            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();

            var modelList = webApiClient.GetTiposDePlantas<List<TipoPlantaviewmodel>>();

            return View(modelList.Data);
        }

        // GET: TipoPlantas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
            var Views = webApiClient.GetTipoPlantaById<TipoPlantaviewmodel>(id.Value);


            if (Views.Data == null)
            {
                return NotFound();
            }


            return View(Views.Data);
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
        public async Task<IActionResult> Create([Bind("TipoPlantaId,Descripcion")] TipoPlantaviewmodel tipoPlanta)
        {
            if (ModelState.IsValid)
            {
                WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
                var Views = webApiClient.PostTipoPlanta<TipoPlantaviewmodel>(tipoPlanta);
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


            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
            var Views = webApiClient.GetTipoPlantaById<TipoPlantaviewmodel>(id.Value);

            if (Views.Data == null)
            {
                return NotFound();
            }

            return View(Views.Data);
        }

        // POST: TipoPlantas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoPlantaId,Descripcion")] TipoPlantaviewmodel tipoPlanta)
        {
            if (ModelState.IsValid)
            {
                WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
                var Views = webApiClient.PutTipoPlanta<TipoPlantaviewmodel, TipoPlanta>(id, tipoPlanta);
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

            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
            var Views = webApiClient.GetTipoPlantaById<TipoPlantaviewmodel>(id.Value);

            if (Views.Data == null)
            {
                return NotFound();
            }
            return View(Views.Data);
        }

        // POST: TipoPlantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();
            var Views = webApiClient.DeleteTipoPlantaById<TipoPlantaviewmodel>(id);
            if (Views.Data == false)
            {
                BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPlantaExists(int id)
        {
            return _context.TipoPlantas.Any(e => e.TipoPlantaId == id);
        }
    }
}
