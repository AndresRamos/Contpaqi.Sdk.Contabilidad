using Autofac;
using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
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

            containerBuilder.RegisterType<ShellViewModel>();

            return containerBuilder.Build();
        }
    }
}