using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualVendingMachine.Domain;

namespace VirtualVendingMachine.Data.DBContext
{
    public class VendingMachineDbContext : BaseDbContext, IVendingMachineDbContext
    {
        public VendingMachineDbContext() : base("VendingMachineDbContext")
        {
            
        }

        public VendingMachineDbContext(string connection) : base(connection)
        {
            
        }

        public IDbSet<Currency> Currencies { get; set; }
        public IDbSet<VendingMachineCoin> VendingMachineCoins { get; set; }
        public IDbSet<VendingMachineProduct> VendingMachineProducts { get; set; }
        public IDbSet<Product> Products { get; set; }
        
    }

    public interface IVendingMachineDbContext
    {
        IDbSet<Currency> Currencies { get; set; }
        IDbSet<VendingMachineCoin> VendingMachineCoins { get; set; }
        IDbSet<VendingMachineProduct> VendingMachineProducts { get; set; }
        IDbSet<Product> Products { get; set; }
        int SaveChanges();
    }
}
