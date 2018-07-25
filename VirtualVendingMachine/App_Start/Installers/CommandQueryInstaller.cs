using Castle.MicroKernel.Registration;
using VirtualVendingMachine.Data;
using ShortBus;
using VirtualVendingMachine.Data.Queries;

namespace VirtualVendingMachine.Installers
{
    public class CommandQueryInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            DependencyResolver.SetResolver(new ShortBus.Windsor.WindsorDependencyResolver(container));

            container.Register(Component.For<IDependencyResolver>().Instance(DependencyResolver.Current));

            container.Register(Component.For(typeof(IMediator)).ImplementedBy(typeof(VendingMachineMediator)));

            container.Register(Classes.FromAssembly(typeof(GetTotalBalanceQuery).Assembly)
                                      .BasedOn
                                      (
                                      typeof(IRequestHandler<,>),
                                      typeof(IAsyncRequestHandler<,>),
                                      typeof(INotificationHandler<>),
                                      typeof(IAsyncNotificationHandler<>)
                                      ).WithService.Base()
                                      .LifestylePerWebRequest()
                );
        }
    }
}