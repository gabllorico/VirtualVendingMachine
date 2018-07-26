
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;
using VirtualVendingMachine.Data.DTO;

namespace VirtualVendingMachine.Data.Queries
{
    public class GetProductsLeftInVendingMachineQuery : IRequest<ProductsLeftWithPortionDto>
    {
    }

    public class GetProductsLeftInVendingMachineQueryHandler :
        IRequestHandler<GetProductsLeftInVendingMachineQuery, ProductsLeftWithPortionDto>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public GetProductsLeftInVendingMachineQueryHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductsLeftWithPortionDto Handle(GetProductsLeftInVendingMachineQuery request)
        {
            var productsLeft = _dbContext.VendingMachineProducts.Include(x => x.Product).ToList();

            var productsLeftInDisplay = new ProductsLeftWithPortionDto
            {
                Products = new List<ProductWithPortionDto>()
            };

            foreach (var vendingMachineProduct in productsLeft)
            {
                productsLeftInDisplay.Products.Add(new ProductWithPortionDto
                {
                    Portion = vendingMachineProduct.Portion,
                    ProductName = vendingMachineProduct.Product.ProductName,
                    ProductId = vendingMachineProduct.Product.Id,
                    Price = vendingMachineProduct.Price
                });
            }

            return productsLeftInDisplay;
        }
    }
}
