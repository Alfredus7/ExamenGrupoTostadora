using AutoMapper;
using Data.Models;

namespace WebApi.AutoMapperProfiles
{
    public class TipoPlantasProfileApi : Profile
    {
        public TipoPlantasProfileApi() 
        {
            CreateMap<TipoPlanta, TipoPlantaDTOS>()
            .ForMember(dest => dest.TipoPlantaId, opt => opt.MapFrom(src => src.TipoPlantaId))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
            .ReverseMap();
        }
    }
}
