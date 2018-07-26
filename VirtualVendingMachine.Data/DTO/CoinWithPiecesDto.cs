using System.Collections.Generic;

namespace VirtualVendingMachine.Data.DTO
{
    public class CoinWithPiecesDto
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public int Pieces { get; set; }
    }

    public class CoinsWithPiecesDto
    {
        public List<CoinWithPiecesDto> Coins { get; set; }
    }
}
