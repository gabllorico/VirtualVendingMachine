using System.Collections.Generic;

namespace VirtualVendingMachine.Data.DTO
{
    public class CoinDto
    {
        public int CurrencyId { get; set; }
        public string CoinName { get; set; }
        public decimal Value { get; set; }
    }

    public class CoinsDto
    {
        public List<CoinDto> Coins { get; set; }
    }
}
