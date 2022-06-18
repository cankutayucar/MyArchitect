using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Abstraction.Services;
using MyArchitect.RequestResponseModels.Category.CreateCategory;
using MyArchitect.RequestResponseModels.Category.UpdateCategory;

namespace MyArchitect.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }

        [Route("name-with-description/get")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesNameWithDescription()
        {
            return Ok(await _categoryService.GetCategoriesNameWithDescriptionAsync());
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _categoryService.GetCategoryByIdAsync(id));
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto category)
        {
            var result = await _categoryService.CreateCategoryAsync(category);
            return result != 0 ? Ok(result) : BadRequest(result);
        }

        [Route("update/{id}")]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UpdateCategoryDto category)
        {
            var result = await _categoryService.UpdateCategoryAsync(id, category);
            return result ? Ok(result) : BadRequest(result);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            return result ? Ok(result) : BadRequest(result);
        }
    }
}
