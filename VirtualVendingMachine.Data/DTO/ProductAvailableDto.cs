using System.Collections.Generic;

namespace VirtualVendingMachine.Data.DTO
{
    public class ProductAvailableDto
    {
        public int VendingMachineProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
    }
    public class ProductsAvailableDto
    {
        public List<ProductAvailableDto> ProductsAvailable { get; set; }
        public List<CoinInsertedDto> CoinsInserted { get; set; }
        public decimal TotalAmountInserted { get; set; }

    }
}
