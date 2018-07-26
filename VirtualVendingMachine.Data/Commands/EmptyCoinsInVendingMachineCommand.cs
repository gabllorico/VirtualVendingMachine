using System.Linq;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;

namespace VirtualVendingMachine.Data.Commands
{
    public class EmptyCoinsInVendingMachineCommand : IRequest<bool>
    {
    }

    public class EmptyCoinsInVendingMachineCommandHandler : IRequestHandler<EmptyCoinsInVendingMachineCommand, bool>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public EmptyCoinsInVendingMachineCommandHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Handle(EmptyCoinsInVendingMachineCommand request)
        {
            var coinsInVendingMachine = _dbContext.VendingMachineCoins.ToList();
            foreach (var vendingMachineCoin in coinsInVendingMachine)
            {
                vendingMachineCoin.Pieces = 0;
            }

            _dbContext.SaveChanges();
            return true;
        }
    }
}
