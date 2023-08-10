using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Ocsp;
using product_api.Brokers;
using product_api.Models;
using product_db.Unit.Tests.Persistance;

namespace product_api.Integration.Tests
{
    public class StorageBrokerIntegrationTests:SqLiteStorageBroker
    {
        private readonly IProductRepository _storageBroker;
        
        public StorageBrokerIntegrationTests()
        {
            _storageBroker = new ProductRepository(_sqlLiteStorageBroker);
        }

        [Fact]
        public async Task ShouldAddProductToDatabase()
        {
            Product product = new Product() { Name="prada bag",Description="yellow prada bag",Price=1929};
            
            await _storageBroker.AddProductAsync(product);
            await _sqlLiteStorageBroker.SaveChangesAsync();


            var result = await _sqlLiteStorageBroker.Products.ToListAsync();

            Assert.Equal(product, result.FirstOrDefault(x=>x.ProductId==product.ProductId));
        }
    }
}