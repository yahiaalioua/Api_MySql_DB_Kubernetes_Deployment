using Microsoft.EntityFrameworkCore;
using product_api.Models;

namespace product_api.Brokers
{
    public  class ProductRepository : IProductRepository
    {
        private readonly StorageBroker _storageBroker;

        public ProductRepository(StorageBroker storageBroker)
        {
            _storageBroker = storageBroker;
        }

        public async Task AddProductAsync(Product product)
        {
            await _storageBroker.Products.AddAsync(product);
        }

        public IQueryable<Product> GetProductsAsync() =>
            _storageBroker.Products;

        public async Task<Product?>GetProductByIdAsync(Guid id)
        {
            return await _storageBroker.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }


    }
}
