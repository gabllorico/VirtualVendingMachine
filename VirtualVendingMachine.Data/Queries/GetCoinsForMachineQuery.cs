using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;
using VirtualVendingMachine.Data.DTO;

namespace VirtualVendingMachine.Data.Queries
{
    public class GetCoinsForMachineQuery : IRequest<CoinsWithPiecesDto>
    {

    }

    public class GetCoinsForMachineQueryHandler : IRequestHandler<GetCoinsForMachineQuery, CoinsWithPiecesDto>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public GetCoinsForMachineQueryHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CoinsWithPiecesDto Handle(GetCoinsForMachineQuery request)
        {
            var coinsWithPieces = new CoinsWithPiecesDto
            {
                Coins = new List<CoinWithPiecesDto>()
            };

            var coins = _dbContext.Currencies.ToList();

            foreach (var coin in coins)
            {
                coinsWithPieces.Coins.Add(new CoinWithPiecesDto
                {
                    CurrencyId = coin.Id,
                    CurrencyName = coin.CoinName,
                    Pieces = 0
                });
            }

            return coinsWithPieces;

        }
    }
}
