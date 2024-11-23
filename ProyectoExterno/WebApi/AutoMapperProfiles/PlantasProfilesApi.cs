using AutoMapper;
using Data.Models;

namespace WebApi.AutoMapperProfiles
{
    public class PlantasProfilesApi : Profile
    {
        public PlantasProfilesApi()
        {
            CreateMap<Planta, PlantasDTOS>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.TipoPlantaId, opt => opt.MapFrom(src => src.TipoPlantaId))
                .ForMember(dest => dest.TipoPlanta, opt => opt.MapFrom(src => src.TipoPlanta))
                .ReverseMap();

        }
    }
}
