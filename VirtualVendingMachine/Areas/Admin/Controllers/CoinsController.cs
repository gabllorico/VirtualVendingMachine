using System.Web.Mvc;
using ShortBus;
using VirtualVendingMachine.Data.Queries;

namespace VirtualVendingMachine.Areas.Admin.Controllers
{
    public class CoinsController : Controller
    {
        private readonly IMediator _mediator;
        public CoinsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Admin/Coins
        public ActionResult Index()
        {
            var model = _mediator.Request(new GetTotalBalanceQuery());
            return View(model);
        }

        public JsonResult AddCoins()
        {
            return new JsonResult();
        }
    }
}