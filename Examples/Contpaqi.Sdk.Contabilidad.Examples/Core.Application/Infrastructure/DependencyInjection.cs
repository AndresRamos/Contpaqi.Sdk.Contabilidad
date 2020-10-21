using Autofac;
using Core.Application.Empresas.Interfaces;
using Core.Application.Empresas.Servicios;
using Core.Application.Sesiones.Interfaces;
using Core.Application.Sesiones.Services;
using SDKCONTPAQNGLib;

namespace Core.Application.Infrastructure
{
    public static class DependencyInjection
    {
        public static ContainerBuilder AddApplication(this ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<TSdkSesion>().SingleInstance();

            containerBuilder.Register(c => new TSdkSesion()).SingleInstance();
            containerBuilder.Register(c => new TSdkListaEmpresas()).SingleInstance();

            containerBuilder.RegisterType<SesionService>().As<ISesionService>().SingleInstance();

            containerBuilder.RegisterType<EmpresasRepository>().As<IEmpresaRepository>();

            return containerBuilder;
        }
    }
}