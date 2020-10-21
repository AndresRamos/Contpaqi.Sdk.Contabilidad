using AutoMapper;
using Core.Application.Empresas.Models;
using SDKCONTPAQNGLib;

namespace Core.Application.Empresas.Mappings
{
    public class EmpresaAutommaperProfile : Profile
    {
        public EmpresaAutommaperProfile()
        {
            CreateMap<TSdkListaEmpresas, EmpresaDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.NombreBaseDatos, opt => opt.MapFrom(src => src.NombreBDD));
            //.ForMember(dest => dest.RutaRespaldo, opt => opt.MapFrom(src => src.RutaResp))
            //.ForMember(dest => dest.RutaDatos, opt => opt.MapFrom(src => src.RutaDatos))
            //.ForMember(dest => dest.UltimaRestauracion, opt => opt.MapFrom(src => src.UltimaRestauracion))
            //.ForMember(dest => dest.UltimoArchivoRespaldo, opt => opt.MapFrom(src => src.UltimoArchivoRespaldo))
            //.ForMember(dest => dest.UltimoRespaldo, opt => opt.MapFrom(src => src.UltimoRespaldo));
        }
    }
}