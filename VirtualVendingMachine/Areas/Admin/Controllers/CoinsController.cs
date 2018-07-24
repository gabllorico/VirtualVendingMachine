using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualVendingMachine.Areas.Admin.Controllers
{
    public class CoinsController : Controller
    {
        // GET: Admin/Coins
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddCoins()
        {
            return new JsonResult();
        }
    }
}