using product_api.Brokers;
using product_api.DTO;
using product_api.Models;

namespace product_api.Services.FoundationServices
{
    public class ProductService : IProductService
    {
        private readonly IStorageBroker _storageBroker;
        private readonly IUnityOfWork _unityOfWork;

        public ProductService(IStorageBroker storageBroker, IUnityOfWork unityOfWork)
        {
            _storageBroker = storageBroker;
            _unityOfWork = unityOfWork;
        }

        public IQueryable<Product> GetProducts()
        {
            return _storageBroker.GetProductsAsync();
        }

        public async Task AddProduct(AddProductDto productDto)
        {
            Product product = new Product()
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
            };
            await _storageBroker.AddProductAsync(product);
            await _unityOfWork.SaveChangesAsync();
        }
    }
}
