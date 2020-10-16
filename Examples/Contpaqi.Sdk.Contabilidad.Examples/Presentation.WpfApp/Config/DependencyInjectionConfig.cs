using System.Reflection;
using Autofac;
using Caliburn.Micro;
using Core.Application.Infrastructure;
using Core.Application.Sesiones.Commands.IniciarConexion;
using MahApps.Metro.Controls.Dialogs;
using MediatR;
using Presentation.WpfApp.ViewModels;

namespace Presentation.WpfApp.Config
{
    public static class DependencyInjectionConfig
    {
        public static IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();

            //  register the single window manager for this container
            containerBuilder.Register<IWindowManager>(c => new WindowManager()).InstancePerLifetimeScope();
            //  register the single event aggregator for this container
            containerBuilder.Register<IEventAggregator>(c => new EventAggregator()).InstancePerLifetimeScope();

            // Mahapps
            containerBuilder.RegisterInstance(DialogCoordinator.Instance).ExternallyOwned();

            // ViewModels
            containerBuilder.RegisterType<ShellViewModel>();

            // Mediatr
            containerBuilder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            containerBuilder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            containerBuilder.RegisterAssemblyTypes(typeof(IniciarConexionCommand).GetTypeInfo().Assembly).AsImplementedInterfaces();

            containerBuilder.AddApplication();

            return containerBuilder.Build();
        }
    }
}