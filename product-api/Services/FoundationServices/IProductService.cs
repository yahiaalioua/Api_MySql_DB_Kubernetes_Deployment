using product_api.DTO;
using product_api.Models;

namespace product_api.Services.FoundationServices
{
    public interface IProductService
    {
        Task AddProduct(AddProductDto productDto);
        IQueryable<Product> GetProducts();
    }
}