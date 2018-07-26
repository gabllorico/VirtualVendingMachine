using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;
using VirtualVendingMachine.Data.DTO;

namespace VirtualVendingMachine.Data.Queries
{
    public class GetCoinsForInsertQuery : IRequest<CoinsDto>
    {
    }

    public class GetCoinsForInsertQueryHandler : IRequestHandler<GetCoinsForInsertQuery, CoinsDto>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public GetCoinsForInsertQueryHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CoinsDto Handle(GetCoinsForInsertQuery request)
        {
            var coins = new CoinsDto
            {
                Coins = new List<CoinDto>()
            };

            var coinsFromDb = _dbContext.Currencies.ToList();

            foreach (var currency in coinsFromDb)
            {
                coins.Coins.Add(new CoinDto
                {
                    CurrencyId = currency.Id,
                    CoinName = currency.CoinName,
                    Value = currency.Value
                });
            }

            return coins;
        }
    }
}
