using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyArchitect.Abstraction.Repositories;

namespace MyArchitect.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private  readonly  IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productRepository.GetAllProductsAsync());
        }
    }
}
