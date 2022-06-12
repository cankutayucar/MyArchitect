using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Abstraction.Services;

namespace MyArchitect.Api.Controllers
{
    [Route("api/categories")]
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
    }
}
