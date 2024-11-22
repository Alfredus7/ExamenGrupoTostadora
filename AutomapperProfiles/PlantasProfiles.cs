using AutoMapper;
using Data.Models;
using ExamenGrupoTostadora.Data.Migrations;
using ExamenGrupoTostadora.ViewModel;

namespace ExamenGrupoTostadora.AutoMapperProfiles
{
    public class PlantasProfiles : Profile
    {
        public PlantasProfiles()
        {
            CreateMap<Planta, Plantasviewmodel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.TipoPlantaId, opt => opt.MapFrom(src => src.TipoPlantaId))
                .ForMember(dest => dest.TipoPlanta, opt => opt.MapFrom(src => src.TipoPlanta))
                .ReverseMap();

        }
    }
}
