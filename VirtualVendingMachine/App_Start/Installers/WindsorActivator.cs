
namespace VirtualVendingMachine.Installers
{
    public class WindsorActivator
    {
        static ContainerBootstrapper _bootstrapper;

        public static void PreStart()
        {
            _bootstrapper = ContainerBootstrapper.Bootstrap();
        }

        public static void Shutdown()
        {
            if (_bootstrapper != null)
                _bootstrapper.Dispose();
        }
    }
}