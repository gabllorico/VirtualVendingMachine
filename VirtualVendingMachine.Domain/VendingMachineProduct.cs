
namespace VirtualVendingMachine.Domain
{
    public class VendingMachineProduct : BaseEntity
    {
        public Product Product { get; set; }
        public int Portion { get; set; }
        public decimal Price { get; set; }
    }
}
