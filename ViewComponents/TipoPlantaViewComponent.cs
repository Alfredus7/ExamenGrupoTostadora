using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ExamenGrupoTostadora.ViewModel;

namespace ExamenGrupoTostadora.ViewComponents
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
            
            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();

            var modelList = webApiClient.GetTiposDePlantas<List<TipoPlantaviewmodel>>();

            return View(modelList.Data);
        }

    }
}