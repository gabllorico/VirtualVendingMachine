using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShortBus;
using VirtualVendingMachine.Data.Commands;
using VirtualVendingMachine.Data.DTO;
using VirtualVendingMachine.Data.Queries;

namespace VirtualVendingMachine.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProducts()
        {
            var request = _mediator.Request(new GetProductsToBeAddedQuery());
            return View(request.Data);
        }

        public ActionResult Add(ProductsWithPortionToBeAddedDto dto)
        {
            var request = _mediator.Request(new AddProductCommand
            {
                Products = dto
            });
            if (request.Data)
                TempData["NotificationMessage"] = "Successfully Added Portions";
            else
                TempData["NotificationMessage"] = "Something Went Wrong With Adding of Portions";
            return RedirectToAction("Index");
        }

        public ActionResult ProductStockList()
        {
            var request = _mediator.Request(new GetProductsLeftInVendingMachineQuery());
            return PartialView("_ProductStockListPartial", request.Data);
        }
    }
}

