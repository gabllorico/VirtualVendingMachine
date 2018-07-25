using System.Web.Http;
using System.Data.Entity;
using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Web.Optimization;
using System.Web.Routing;
using VirtualVendingMachine.Data.DBContext;

namespace VirtualVendingMachine
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static WindsorContainer Container { get; set; }

        protected void Application_Start()
        {


            Database.SetInitializer(new VendingMachineDbContextInitializer());

            AreaRegistration.RegisterAllAreas();

            BootstrapContainer();
            

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void BootstrapContainer()
        {
            Container = new WindsorContainer();
            Container.Install(FromAssembly.This());
        }
    }
}
