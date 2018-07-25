using System;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace VirtualVendingMachine.Installers
{
    public class ContainerBootstrapper : IContainerAccessor, IDisposable
    {

        readonly IWindsorContainer _container;

        ContainerBootstrapper(IWindsorContainer container)
        {
            _container = container;
        }

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        public static ContainerBootstrapper Bootstrap()
        {
            var container = new WindsorContainer().
                Install(FromAssembly.This());
            return new ContainerBootstrapper(container);
        }

        public void Dispose()
        {
            Container.Dispose();
        }

    }
}