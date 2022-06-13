using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Abstraction.Services;

namespace MyArchitect.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private  readonly  IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProductAsync());
        }
        
        [Route("get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productService.GetProductByIdAsync(id));
        }
    }
}
