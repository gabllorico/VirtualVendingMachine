using System.Data.Entity;
using System.Linq;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;
using VirtualVendingMachine.Data.DTO;

namespace VirtualVendingMachine.Data.Commands
{
    public class AddCoinsCommand : IRequest<bool>
    {
        public CoinsWithPiecesDto CoinsWithPieces { get; set; }
    }

    public class AddCoinsCommandHandler : IRequestHandler<AddCoinsCommand, bool>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public AddCoinsCommandHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Handle(AddCoinsCommand request)
        {
            foreach (var coinWithPiece in request.CoinsWithPieces.Coins)
            {
                var currency = _dbContext.VendingMachineCoins.Include(x => x.Currency).First(x => x.Currency.Id == coinWithPiece.CurrencyId);
                currency.Pieces = currency.Pieces + coinWithPiece.Pieces;
            }
            _dbContext.SaveChanges();
            return true;
        }
    }
}
