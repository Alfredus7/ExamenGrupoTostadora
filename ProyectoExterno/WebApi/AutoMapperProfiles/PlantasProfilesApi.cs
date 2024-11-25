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
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(dest => dest.ImagenUrl, opt => opt.MapFrom(src => src.ImagenUrl))
                .ForMember(dest => dest.Tamaño, opt => opt.MapFrom(src => src.Tamaño))
                .ForMember(dest => dest.Disponible, opt => opt.MapFrom(src => src.Disponible))




                .ForMember(dest => dest.TipoPlantaId, opt => opt.MapFrom(src => src.TipoPlantaId))
                .ForMember(dest => dest.TipoPlanta, opt => opt.MapFrom(src => src.TipoPlanta))
                .ReverseMap();

        }
    }
}
