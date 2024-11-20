using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPlantasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoPlantasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoPlantas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPlanta>>> GetTipoPlantas()
        {
            return await _context.TipoPlantas.ToListAsync();
        }

        // GET: api/TipoPlantas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPlanta>> GetTipoPlanta(int id)
        {
            var tipoPlanta = await _context.TipoPlantas.FindAsync(id);

            if (tipoPlanta == null)
            {
                return NotFound();
            }

            return tipoPlanta;
        }

        // PUT: api/TipoPlantas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPlanta(int id, TipoPlanta tipoPlanta)
        {
            if (id != tipoPlanta.TipoPlantaId)
            {
                return BadRequest();
            }

            _context.Entry(tipoPlanta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPlantaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoPlantas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoPlanta>> PostTipoPlanta(TipoPlanta tipoPlanta)
        {
            _context.TipoPlantas.Add(tipoPlanta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPlanta", new { id = tipoPlanta.TipoPlantaId }, tipoPlanta);
        }

        // DELETE: api/TipoPlantas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPlanta(int id)
        {
            var tipoPlanta = await _context.TipoPlantas.FindAsync(id);
            if (tipoPlanta == null)
            {
                return NotFound();
            }

            _context.TipoPlantas.Remove(tipoPlanta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoPlantaExists(int id)
        {
            return _context.TipoPlantas.Any(e => e.TipoPlantaId == id);
        }
    }
}
