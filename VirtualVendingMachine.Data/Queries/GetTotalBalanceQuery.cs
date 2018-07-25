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
            var y = _dbContext.VendingMachineCoins.ToList();
            decimal x = 1;
            return x;
        }
    }
}
