using System.Web.Mvc;
using ShortBus;
using VirtualVendingMachine.Data.Queries;

namespace VirtualVendingMachine.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {

            _mediator = mediator;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ReadMe()
        {
            return View();
        }
    }
}
