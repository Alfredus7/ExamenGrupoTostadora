using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using AutoMapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPlantasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TipoPlantasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TipoPlantas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPlantaDTOS>>> GetTipoPlantas()
        {
            var entidades = await _context.TipoPlantas.ToListAsync();
            var modelList = _mapper.Map<List<TipoPlantaDTOS>>(entidades);
            return Ok(modelList);
        }

        // GET: api/TipoPlantas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPlantaDTOS>> GetTipoPlanta(int id)
        {
            var tipoPlanta = await _context.TipoPlantas.FindAsync(id);

            if (tipoPlanta == null)
            {
                return NotFound();
            }

            var tipoPlantaDto = _mapper.Map<TipoPlantaDTOS>(tipoPlanta);
            return Ok(tipoPlantaDto);
        }

        // PUT: api/TipoPlantas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPlanta(int id, TipoPlantaDTOS tipoPlantaDto)
        {
            if (id != tipoPlantaDto.TipoPlantaId)
            {
                return BadRequest();
            }

            var tipoPlantaEntity = _mapper.Map<TipoPlanta>(tipoPlantaDto);
            _context.Entry(tipoPlantaEntity).State = EntityState.Modified;

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
        [HttpPost]
        public async Task<ActionResult<TipoPlantaDTOS>> PostTipoPlanta(TipoPlantaDTOS tipoPlantaDto)
        {
            var tipoPlantaEntity = _mapper.Map<TipoPlanta>(tipoPlantaDto);
            _context.TipoPlantas.Add(tipoPlantaEntity);
            await _context.SaveChangesAsync();

            var createdTipoPlantaDto = _mapper.Map<TipoPlantaDTOS>(tipoPlantaEntity);

            return CreatedAtAction("GetTipoPlanta", new { id = createdTipoPlantaDto.TipoPlantaId }, createdTipoPlantaDto);
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
