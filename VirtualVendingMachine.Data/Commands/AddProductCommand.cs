
using System.Data.Entity;
using System.Linq;
using ShortBus;
using VirtualVendingMachine.Data.DBContext;
using VirtualVendingMachine.Data.DTO;

namespace VirtualVendingMachine.Data.Commands
{
    public class AddProductCommand : IRequest<bool>
    {
        public ProductsWithPortionToBeAddedDto Products { get; set; }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        private readonly IVendingMachineDbContext _dbContext;

        public AddProductCommandHandler(IVendingMachineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Handle(AddProductCommand request)
        {

            foreach (var product in request.Products.Products)
            {
                var productToBeUpdated =
                    _dbContext.VendingMachineProducts.Include(x => x.Product)
                        .First(x => x.Product.Id == product.ProductId);

                productToBeUpdated.Portion = productToBeUpdated.Portion + product.Portion;
                productToBeUpdated.Price = product.Price;
            }
            _dbContext.SaveChanges();
            return true;
        }
    }
}
