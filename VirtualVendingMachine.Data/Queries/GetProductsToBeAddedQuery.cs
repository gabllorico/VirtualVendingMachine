using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;
using VirtualVendingMachine.Data.DTO;

namespace VirtualVendingMachine.Data.Queries
{
    public class GetProductsToBeAddedQuery : IRequest<ProductsWithPortionToBeAddedDto>
    {
    }

    public class GetProductsToBeAddedQueryHandler :
        IRequestHandler<GetProductsToBeAddedQuery, ProductsWithPortionToBeAddedDto>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public GetProductsToBeAddedQueryHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductsWithPortionToBeAddedDto Handle(GetProductsToBeAddedQuery request)
        {
            var products = _dbContext.VendingMachineProducts.Include(x => x.Product).ToList();

            var productsToBeAdded = new ProductsWithPortionToBeAddedDto
            {
                Products = new List<ProductWithPortionDto>()
            };

            foreach (var vendingMachineProduct in products)
            {
                productsToBeAdded.Products.Add(new ProductWithPortionDto
                {
                    Portion = 0,
                    ProductName = vendingMachineProduct.Product.ProductName,
                    ProductId = vendingMachineProduct.Product.Id,
                    Price = vendingMachineProduct.Price
                });
            }

            return productsToBeAdded;
        }
    }
}
