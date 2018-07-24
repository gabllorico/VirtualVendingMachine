
namespace VirtualVendingMachine.Domain
{
    public class VendingMachineCoin : BaseEntity
    {
        public Currency Currency { get; set; }
        public int Pieces { get; set; }
        public decimal TotalAmount => Currency.Value * Pieces;
    }
}
