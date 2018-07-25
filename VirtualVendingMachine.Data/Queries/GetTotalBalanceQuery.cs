using System.Data.Entity;
using System.Linq;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;

namespace VirtualVendingMachine.Data.Queries
{
    public class GetTotalBalanceQuery : IRequest<decimal>
    {
    }

    public class GetTotalBalanceQueryHandler : IRequestHandler<GetTotalBalanceQuery, decimal>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public GetTotalBalanceQueryHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public decimal Handle(GetTotalBalanceQuery request)
        {
            var coinsInVending = _dbContext.VendingMachineCoins.Include(x => x.Currency).ToList();
            decimal totalAmount = 0;

            foreach (var coinInVending in coinsInVending)
            {
                totalAmount = totalAmount + coinInVending.TotalAmount;
            }

            return totalAmount;
        }
    }
}
