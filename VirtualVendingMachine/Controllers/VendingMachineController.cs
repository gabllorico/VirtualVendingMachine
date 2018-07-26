using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ShortBus;
using VirtualVendingMachine.Data.Commands;
using VirtualVendingMachine.Data.DTO;
using VirtualVendingMachine.Data.Queries;

namespace VirtualVendingMachine.Controllers
{
    public class VendingMachineController : Controller
    {
        private readonly IMediator _mediator;

        public VendingMachineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: VendingMachine
        public ActionResult Index()
        {
            var request = _mediator.Request(new GetProductsAvailableInVendingMachineWithCoinsQuery
            {
                CoinsInserted = new List<CoinInsertedDto>()
            });
            return View(request.Data);
        }

        public ActionResult VendingMachine([FromBody] List<CoinInsertedDto> dto)
        {
            var request = _mediator.Request(new GetProductsAvailableInVendingMachineWithCoinsQuery
            {
                CoinsInserted = dto
            });
            return View(request.Data);
        }

        public ActionResult CoinListPartial()
        {
            var request = _mediator.Request(new GetCoinsForInsertQuery());
            return PartialView("_CoinListPartial", request.Data);
        }

        public ActionResult CoinBack([FromBody] List<CoinInsertedDto> dto)
        {
            var request = _mediator.Request(new CoinBackCommand
            {
                CoinsInserted = dto
            });

            TempData["CoinBack"] = request.Data;

            return RedirectToAction("VendingMachine", new {dto = new List<CoinInsertedDto>()});
        }

        public ActionResult OrderVendingMachineProduct(int vendingMachineProductId, decimal totalAmountInserted)
        {
            var request = _mediator.Request(new OrderProductCommand
            {
                VendingMachineProductId = vendingMachineProductId,
                AmountInserted = totalAmountInserted
            });

            TempData["NotificationMessage"] = "Success";
            TempData["CoinChange"] = request.Data;
            return RedirectToAction("VendingMachine", new {dto = new List<CoinInsertedDto>()});
        }
    }
}