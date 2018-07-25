using System.Data;
using ShortBus;

namespace VirtualVendingMachine.Data
{
    public class VendingMachineMediator : Mediator
    {
        public VendingMachineMediator(IDependencyResolver dependencyResolver)
            : base(dependencyResolver)
        {

        }
    }
}
