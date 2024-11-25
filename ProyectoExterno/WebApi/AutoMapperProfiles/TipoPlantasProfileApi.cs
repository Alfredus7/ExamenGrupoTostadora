using AutoMapper;
using Data.Models;

namespace WebApi.AutoMapperProfiles
{
    public class TipoPlantasProfileApi : Profile
    {
        public TipoPlantasProfileApi() 
        {
            CreateMap<TipoPlanta, TipoPlantaDTOS>()

            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Caracteristicas, opt => opt.MapFrom(src => src.Caracteristicas))
            .ForMember(dest => dest.Habitat, opt => opt.MapFrom(src => src.Habitat))
            .ForMember(dest => dest.ClimaIdeal, opt => opt.MapFrom(src => src.ClimaIdeal))
            .ForMember(dest => dest.EsComestible, opt => opt.MapFrom(src => src.EsComestible))
           


            .ForMember(dest => dest.TipoPlantaId, opt => opt.MapFrom(src => src.TipoPlantaId))

            .ReverseMap();
        }
    }
}
