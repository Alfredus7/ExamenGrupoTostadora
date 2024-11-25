using AutoMapper;
using Data.Models;
using ExamenGrupoTostadora.ViewModel;

namespace ExamenGrupoTostadora.AutoMapperProfiles
{
    public class TipoPlantasProfile : Profile
    {
        public TipoPlantasProfile() 
        {
            CreateMap<TipoPlanta, TipoPlantaviewmodel>()
            .ForMember(dest => dest.TipoPlantaId, opt => opt.MapFrom(src => src.TipoPlantaId))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
            .ReverseMap();
        }
    }
}
