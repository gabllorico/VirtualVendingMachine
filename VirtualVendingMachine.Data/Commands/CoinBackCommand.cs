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
    public class CoinBackCommand : IRequest<CoinChangesDto>
    {
        public List<CoinInsertedDto> CoinsInserted { get; set; }
    }

    public class CoinBackCommandHandler : IRequestHandler<CoinBackCommand, CoinChangesDto>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public CoinBackCommandHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CoinChangesDto Handle(CoinBackCommand request)
        {
            var coinReturned = new CoinChangesDto
            {
                CoinChanges = new List<CoinChangeDto>()
            };
            foreach (var coinInserted in request.CoinsInserted)
            {
                var coinToBeRemoved =
                    _dbContext.VendingMachineCoins.Include(x => x.Currency)
                        .First(x => x.Currency.Id == coinInserted.CurrencyId);

                coinToBeRemoved.Pieces = coinToBeRemoved.Pieces - coinInserted.Pieces;
                coinReturned.CoinChanges.Add(new CoinChangeDto
                {
                    CurrencyId = coinToBeRemoved.Currency.Id,
                    Pieces = coinInserted.Pieces,
                    CurrencyName = coinToBeRemoved.Currency.CoinName,
                    Value = coinToBeRemoved.Currency.Value
                });
            }

            _dbContext.SaveChanges();
            
            return coinReturned;
        }
    }
}
