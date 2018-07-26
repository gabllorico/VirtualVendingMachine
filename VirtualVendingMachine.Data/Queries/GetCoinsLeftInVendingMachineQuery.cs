using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;
using VirtualVendingMachine.Data.DTO;

namespace VirtualVendingMachine.Data.Queries
{
    public class GetCoinsLeftInVendingMachineQuery : IRequest<CoinChangesDto>
    {
    }

    public class GetCoinsLeftInVendingMachineQueryHandler :
        IRequestHandler<GetCoinsLeftInVendingMachineQuery, CoinChangesDto>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public GetCoinsLeftInVendingMachineQueryHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CoinChangesDto Handle(GetCoinsLeftInVendingMachineQuery request)
        {
            var coinsLeftInMachine = _dbContext.VendingMachineCoins.Include(x => x.Currency).ToList();

            var coinsToBeDisplayed = new CoinChangesDto
            {
                CoinChanges = new List<CoinChangeDto>()
            };

            foreach (var vendingMachineCoin in coinsLeftInMachine)
            {
                coinsToBeDisplayed.CoinChanges.Add(new CoinChangeDto
                {
                    CurrencyId = vendingMachineCoin.Currency.Id,
                    Pieces = vendingMachineCoin.Pieces,
                    Value = vendingMachineCoin.Currency.Value,
                    CurrencyName = vendingMachineCoin.Currency.CoinName
                });
            }

            return coinsToBeDisplayed;
        }
    }
}
