using Autofac;
using Core.Application.CuentasContables.Interfaces;
using Core.Application.CuentasContables.Services;
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

            containerBuilder.Register(c =>
            {
                var sdkSesion = c.Resolve<TSdkSesion>();

                var sdkCuenta = new TSdkCuenta();
                sdkCuenta.setSesion(sdkSesion);

                return sdkCuenta;
            });

            containerBuilder.RegisterType<SesionService>().As<ISesionService>().SingleInstance();

            containerBuilder.RegisterType<EmpresasRepository>().As<IEmpresaRepository>();
            containerBuilder.RegisterType<CuentaContableRepository>().As<ICuentaContableRepository>();

            return containerBuilder;
        }
    }
}