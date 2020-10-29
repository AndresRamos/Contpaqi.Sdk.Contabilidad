using AutoMapper;
using Core.Application.CuentasContables.Models;
using SDKCONTPAQNGLib;

namespace Core.Application.CuentasContables.Mappings
{
    public class CuentaContableAutomapperProfile : Profile
    {
        public CuentaContableAutomapperProfile()
        {
            CreateMap<TSdkCuenta, CuentaContableDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.NombreIngles, opt => opt.MapFrom(src => src.NomIdioma))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.CuentaDeMayor, opt => opt.MapFrom(src => src.CtaMayor))
                .ForMember(dest => dest.AceptaSegmentoNegocio, opt => opt.MapFrom(src => src.AplicaSegNeg))
                .ForMember(dest => dest.Moneda, opt => opt.MapFrom(src => src.Moneda))
                .ForMember(dest => dest.FechaAlta, opt => opt.MapFrom(src => src.FechaAlta));
        }
    }
}