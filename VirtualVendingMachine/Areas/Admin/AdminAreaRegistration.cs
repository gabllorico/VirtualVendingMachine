using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualVendingMachine.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "admin_default",
                "Admin/{controller}/{action}/{id}",
                new {action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}