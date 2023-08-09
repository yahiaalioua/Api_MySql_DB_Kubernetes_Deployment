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
        private readonly Mock<IStorageBroker> _storageBroker;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _unityOfWork=new Mock<IUnityOfWork>();
            _storageBroker=new Mock<IStorageBroker>();
            _productService=new ProductService(_storageBroker.Object,_unityOfWork.Object);
        }

        [Fact]
        public async Task ShouldAddProductToDb()
        {
            //arrange
            AddProductDto productDto = new("shoes", "43 black", 120);
            _storageBroker.Setup(x => x.AddProductAsync(It.IsAny<Product>()));
            _unityOfWork.Setup(x => x.SaveChangesAsync());
            //act

            await _productService.AddProduct(productDto);
            //assert
            _storageBroker.Verify(x=>x.AddProductAsync(It.IsAny<Product>()), Times.Once());
            _unityOfWork.Verify(x=>x.SaveChangesAsync(), Times.Once());


        }
    }
}