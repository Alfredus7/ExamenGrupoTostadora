using AutoMapper;
using ExamenGrupoTostadora.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ExamenGrupoTostadora.Data;

namespace Unidad3P1.ViewComponents
{
    public class TipoPlantaViewComponent : ViewComponent
    {
        public ApplicationDbContext Context { get; }
        public IMapper Mapper { get; }
        public TipoPlantaViewComponent(ApplicationDbContext context,
            IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var entidades = await Context.TipoPlantas.ToListAsync();
            var modelList = Mapper.Map<List<TipoPlantaviewmodel>>(entidades);
            return View(modelList);
        }

    }
}