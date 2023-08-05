using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using product_api.DTO;
using product_api.Services.FoundationServices;

namespace product_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto productDto)
        {
            await _productService.AddProduct(productDto);
            return Ok();
        }
    }
}
