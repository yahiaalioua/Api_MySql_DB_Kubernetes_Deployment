using product_api.Models;

namespace product_api.Brokers
{
    public partial interface IStorageBroker
    {
        Task AddProductAsync(Product product);
        IQueryable<Product> GetProductsAsync();
    }
}