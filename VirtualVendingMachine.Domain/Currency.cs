namespace VirtualVendingMachine.Domain
{
    public class Currency : BaseEntity
    {
        public string CoinName { get; set; }
        public decimal Value { get; set; }
    }
}
