using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ExamenGrupoTostadora.Data;
using ExamenGrupoTostadora.ViewModel;

namespace ExamenGrupoTostadora.ViewComponents
{
    public class PlantasViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PlantasViewComponent(ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {

            var entidades = await _context.Plantas
                .Where(x => x.TipoPlantaId == id)
                .ToListAsync();
            var modelsList = _mapper.Map<List<Plantasviewmodel>>(entidades);

            return View(modelsList);
        }
    }
}
