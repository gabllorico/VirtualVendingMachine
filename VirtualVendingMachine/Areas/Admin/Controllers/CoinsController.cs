using System.Web.Mvc;
using ShortBus;
using VirtualVendingMachine.Data.DTO;
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
            return View(model.Data);
        }

        public ActionResult AddCoins()
        {
            var request = _mediator.Request(new GetCoinsForMachineQuery());
            return View(request.Data);
        }

        public ActionResult Add(CoinsWithPiecesDto dto)
        {
            var x = dto;
            return RedirectToAction("Index");
        }
    }
}