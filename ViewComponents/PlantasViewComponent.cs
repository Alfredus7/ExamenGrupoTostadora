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
            WebApiClients.WebApiClient webApiClient = new WebApiClients.WebApiClient();

            var modelList = webApiClient.GetPlantas<List<Plantasviewmodel>>();

            return View(modelList.Data);
        }
    }
}
