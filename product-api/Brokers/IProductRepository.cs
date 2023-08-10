using product_api.Models;

namespace product_api.Brokers
{
    public partial interface IProductRepository
    {
        Task AddProductAsync(Product product);
        IQueryable<Product> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(Guid id);
    }
}