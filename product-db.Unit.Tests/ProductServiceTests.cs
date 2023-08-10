using Moq;
using product_api.Brokers;
using product_api.DTO;
using product_api.Models;
using product_api.Services;
using product_api.Services.FoundationServices;

namespace product_db.Unit.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IUnityOfWork> _unityOfWork;
        private readonly Mock<IProductRepository> _storageBroker;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _unityOfWork=new Mock<IUnityOfWork>();
            _storageBroker=new Mock<IProductRepository>();
            _productService=new ProductService(_storageBroker.Object,_unityOfWork.Object);
        }

        [Fact]
        public async Task ShouldAddProductToDb()
        {
            //arrange
            AddProductDto productDto = new("nike sneakers", "43 black", 120);
            _storageBroker.Setup(x => x.AddProductAsync(It.IsAny<Product>()));
            _unityOfWork.Setup(x => x.SaveChangesAsync());
            //act

            await _productService.AddProduct(productDto);
            //assert
            _storageBroker.Verify(x=>x.AddProductAsync(It.IsAny<Product>()), Times.Once());
            _unityOfWork.Verify(x=>x.SaveChangesAsync(), Times.Once());


        }

        [Fact]
        public void ShouldGetAllProductsFromDb()
        {
            //arrange
            _storageBroker.Setup(x => x.GetProductsAsync()).Returns(Enumerable.Empty<Product>().AsQueryable());
            //act

            _productService.GetProducts();
            //assert
            _storageBroker.Verify(x => x.GetProductsAsync(), Times.Once());


        }
    }
}