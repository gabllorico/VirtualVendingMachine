using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;
using VirtualVendingMachine.Data.DTO;

namespace VirtualVendingMachine.Data.Commands
{
    public class OrderProductCommand : IRequest<CoinChangesDto>
    {
        public int VendingMachineProductId { get; set; }
        public decimal AmountInserted { get; set; }
    }

    public class OrderProductCommandHandler : IRequestHandler<OrderProductCommand, CoinChangesDto>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public OrderProductCommandHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CoinChangesDto Handle(OrderProductCommand request)
        {
            var vendingMachineProduct =
                _dbContext.VendingMachineProducts.First(x => x.Id == request.VendingMachineProductId);

            vendingMachineProduct.Portion = vendingMachineProduct.Portion - 1;

            var change = request.AmountInserted - vendingMachineProduct.Price;

            var coinsInMachine =
                _dbContext.VendingMachineCoins.Include(x => x.Currency).Where(x => x.Pieces != 0).OrderByDescending(x => x.Currency.Value).ToList();

            var changes = new CoinChangesDto
            {
                CoinChanges = new List<CoinChangeDto>()
            };

            while (change != 0)
            {
                foreach (var coin in coinsInMachine)
                {
                    while (change >= coin.Currency.Value && coin.Pieces != 0)
                    {
                        change = change - coin.Currency.Value;
                        coin.Pieces = coin.Pieces - 1;
                        if (changes.CoinChanges.FirstOrDefault(x => x.CurrencyId == coin.Currency.Id) == null)
                        {
                            changes.CoinChanges.Add(new CoinChangeDto
                            {
                                CurrencyName = coin.Currency.CoinName,
                                Value = coin.Currency.Value,
                                Pieces = 1,
                                CurrencyId = coin.Currency.Id
                            });
                        }
                        else
                        {
                            var updateCountOfChange = changes.CoinChanges.First(x => x.CurrencyId == coin.Currency.Id);

                            updateCountOfChange.Pieces = updateCountOfChange.Pieces + 1;
                        }
                    }
                }

                if (change != 0)
                    break;

                _dbContext.SaveChanges();
            }


            

            return changes;
        }
    }
}
