using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;

namespace VirtualVendingMachine.Data.Commands
{
    public class AddCoinsCommand : IRequest<bool>
    {

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
            return true;
        }
    }
}
