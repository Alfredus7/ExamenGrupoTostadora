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
    public class PlantasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PlantasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Plantas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantasDTOS>>> GetPlantas()
        {
            var plantas = await _context.Plantas
                                        .Include(p => p.TipoPlanta) // Include the Categoria
                                        .ToListAsync();

            var plantasDto = _mapper.Map<List<PlantasDTOS>>(plantas); // Map to DTO

            return Ok(plantasDto);
        }

        // GET: api/Plantas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantasDTOS>> GetPlanta(int id)
        {
            var planta = await _context.Plantas
                                        .Include(p => p.TipoPlanta) // Include the Categoria
                                        .FirstOrDefaultAsync(p => p.Id == id);

            if (planta == null)
            {
                return NotFound();
            }

            var plantaDto = _mapper.Map<PlantasDTOS>(planta); // Map to DTO
            return Ok(plantaDto);
        }

        // PUT: api/Plantas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanta(int id, PlantasDTOS plantaDto)
        {
            if (id != plantaDto.Id)
            {
                return BadRequest();
            }

            var plantaEntity = _mapper.Map<Planta>(plantaDto);
            _context.Entry(plantaEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantaExists(id))
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

        // POST: api/Plantas
        [HttpPost]
        public async Task<ActionResult<PlantasDTOS>> PostPlanta(PlantasDTOS plantaDto)
        {
            var plantaEntity = _mapper.Map<Planta>(plantaDto);

            _context.Plantas.Add(plantaEntity);
            await _context.SaveChangesAsync();

            var newPlantaDto = _mapper.Map<PlantasDTOS>(plantaEntity);

            return CreatedAtAction("GetPlanta", new { id = plantaEntity.Id }, newPlantaDto);
        }

        // DELETE: api/Plantas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanta(int id)
        {
            var planta = await _context.Plantas.FindAsync(id);
            if (planta == null)
            {
                return NotFound();
            }

            _context.Plantas.Remove(planta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantaExists(int id)
        {
            return _context.Plantas.Any(e => e.Id == id);
        }
    }
}

