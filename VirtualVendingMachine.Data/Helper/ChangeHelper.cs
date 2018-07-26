using System.Data.Entity;
using System.Linq;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;
using VirtualVendingMachine.Data.DTO;

namespace VirtualVendingMachine.Data.Helper
{
    public class ChangeHelper
    {
        private readonly IVendingMachineDbContext _dbContext = new VendingMachineDbContext();

        public bool CanGiveChange(decimal amountInserted, int vendingMachineProductId)
        {
            var coinsInMachine =
                _dbContext.VendingMachineCoins.Include(x => x.Currency).OrderBy(x => x.Currency.Value).ToList();
            var vendingMachineProduct =
                _dbContext.VendingMachineProducts.First(x => x.Id == vendingMachineProductId);

            var change = amountInserted - vendingMachineProduct.Price;

            while (change != 0)
            {
                foreach (var coin in coinsInMachine)
                {
                    while (change >= coin.Currency.Value && coin.Pieces != 0)
                    {
                        change = change - coin.Currency.Value;
                        coin.Pieces = coin.Pieces - 1;
                    }
                }

                if (change != 0)
                    break;
            }


            return change == 0;
        }

    }
}