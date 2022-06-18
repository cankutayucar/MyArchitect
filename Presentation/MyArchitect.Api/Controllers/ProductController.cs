using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Abstraction.Services;
using MyArchitect.RequestResponseModels.Product.CreateProduct;
using MyArchitect.RequestResponseModels.Product.UpdateProduct;

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

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var result = await _productService.InsertProductAsync(dto);
            return result != 0 ? Ok() : BadRequest(result);
        }

        [Route("update/{id}")]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UpdateProductDto dto)
        {
            var result = await _productService.UpdateProductAsync(id, dto);
            return result ? Ok() : BadRequest(result);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            return result ? Ok() : BadRequest(result);
        }
    }
}
