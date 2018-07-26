using System.Collections.Generic;

namespace VirtualVendingMachine.Data.DTO
{
    public class CoinInsertedDto
    {
        public int CurrencyId { get; set; }
        public int Pieces { get; set; }
    }

    public class CoinsInsertedDto
    {
        public List<CoinInsertedDto> CoinsInserted { get; set; }
    }
}
