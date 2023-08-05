using Microsoft.EntityFrameworkCore;
using product_api.Models;

namespace product_api.Brokers
{
    public class StorageBroker : IStorageBroker
    {

        private readonly MySqlStorageBroker _storageBroker;

        public StorageBroker(MySqlStorageBroker storageBroker)
        {
            _storageBroker = storageBroker;
        }

        public async Task AddProductAsync(Product product)
        {
            await _storageBroker.Products.AddAsync(product);
        }

        public IQueryable<Product> GetProductsAsync() =>
            _storageBroker.Products;


    }
}
