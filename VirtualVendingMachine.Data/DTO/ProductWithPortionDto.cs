
using System.Collections.Generic;

namespace VirtualVendingMachine.Data.DTO
{
    public class ProductWithPortionDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Portion { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductsLeftWithPortionDto
    {
        public List<ProductWithPortionDto> Products { get; set; }
    }

    public class ProductsWithPortionToBeAddedDto
    {
        public List<ProductWithPortionDto> Products { get; set; }
    }
}
