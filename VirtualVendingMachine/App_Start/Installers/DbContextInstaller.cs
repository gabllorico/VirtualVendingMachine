using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using VirtualVendingMachine.Data.DBContext;

namespace VirtualVendingMachine.Installers
{
    public class DbContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container,
                            IConfigurationStore store)
        {
            container.Register(Component.For<IVendingMachineDbContext>().ImplementedBy(typeof (VendingMachineDbContext))
                .DependsOn(Dependency.OnValue<string>("name=VendingMachineDbContext")).LifestylePerWebRequest());
        }
    }
}