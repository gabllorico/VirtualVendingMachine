using System.Collections.Generic;

namespace VirtualVendingMachine.Data.DTO
{
    public class CoinChangeDto
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public decimal Value { get; set; }
        public int Pieces { get; set; }

        public decimal Total
        {
            get { return Value*Pieces; }
        }
    }

    public class CoinChangesDto
    {
        public List<CoinChangeDto> CoinChanges { get; set; }

        public decimal TotalChange
        {
            get
            {
                decimal totalChange = 0;
                foreach (var coinChange in CoinChanges)
                {
                    totalChange = totalChange + coinChange.Total;
                }
                return totalChange;
            }
        }
    }
}
