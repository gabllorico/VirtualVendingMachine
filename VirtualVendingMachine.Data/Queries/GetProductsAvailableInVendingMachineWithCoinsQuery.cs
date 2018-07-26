using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;
using VirtualVendingMachine.Data.DTO;
using VirtualVendingMachine.Data.Helper;

namespace VirtualVendingMachine.Data.Queries
{
    public class GetProductsAvailableInVendingMachineWithCoinsQuery : IRequest<ProductsAvailableDto>
    {
        public List<CoinInsertedDto> CoinsInserted { get; set; }
    }

    public class GetProductsAvailableInVendingMachineWithCoinsQueryHandler :
        IRequestHandler<GetProductsAvailableInVendingMachineWithCoinsQuery, ProductsAvailableDto>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public GetProductsAvailableInVendingMachineWithCoinsQueryHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductsAvailableDto Handle(GetProductsAvailableInVendingMachineWithCoinsQuery request)
        {
            decimal insertedMoney = 0;
            if (request.CoinsInserted == null)
            {
                request.CoinsInserted = new List<CoinInsertedDto>();
            }
            var productsDisplay = new ProductsAvailableDto
            {
                ProductsAvailable = new List<ProductAvailableDto>(),
                CoinsInserted = new List<CoinInsertedDto>(),
                TotalAmountInserted = 0
            };


            if (request.CoinsInserted.Count != 0)
            {
                foreach (var coinInserted in request.CoinsInserted)
                {
                    var currency = _dbContext.Currencies.First(x => x.Id == coinInserted.CurrencyId);
                    var amount = currency.Value;
                    insertedMoney = insertedMoney + (amount*coinInserted.Pieces);
                    productsDisplay.CoinsInserted.Add(new CoinInsertedDto
                    {
                        CurrencyId = coinInserted.CurrencyId,
                        Pieces = coinInserted.Pieces
                    });
                    var currencyInVendingMachine =
                        _dbContext.VendingMachineCoins.Include(x => x.Currency).First(x => x.Currency.Id == currency.Id);

                    currencyInVendingMachine.Pieces = currencyInVendingMachine.Pieces + coinInserted.Pieces;
                }

                productsDisplay.TotalAmountInserted = insertedMoney;

                _dbContext.SaveChanges();
            }


            var vendingMachineProducts = _dbContext.VendingMachineProducts.Include(x => x.Product).ToList();

            foreach (var vendingMachineProduct in vendingMachineProducts)
            {
                var product = new ProductAvailableDto
                {
                    ProductName = vendingMachineProduct.Product.ProductName,
                    Price = vendingMachineProduct.Price,
                    VendingMachineProductId = vendingMachineProduct.Id
                };

                if (vendingMachineProduct.Portion != 0 && vendingMachineProduct.Price <= insertedMoney && new ChangeHelper().CanGiveChange(insertedMoney, vendingMachineProduct.Id))
                {
                    product.Available = true;
                    product.Message = "Available";
                }

                else
                {

                    product.Available = false;
                    
                    if (vendingMachineProduct.Portion == 0)
                        product.Message = "Not Available";

                    if (vendingMachineProduct.Price > insertedMoney)
                        product.Message = "Insufficient Amount";

                    if (new ChangeHelper().CanGiveChange(insertedMoney, vendingMachineProduct.Id))
                        product.Message = "Cannot Give Change";
                }

                productsDisplay.ProductsAvailable.Add(product);
            }

            return productsDisplay;
        }
    }
}
