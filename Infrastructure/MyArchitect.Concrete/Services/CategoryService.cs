using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Abstraction.Services;
using MyArchitect.RequestResponseModels.Category.GetAllCategories;
using MyArchitect.RequestResponseModels.Category.GetCategoriesNameWithDescription;

namespace MyArchitect.Concrete.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetAllCategoriesAsync();
            return categoriesEntity.Select(c => new CategoryResponseDto
            {
                CreateDate = c.CreateDate,
                Description = c.Description,
                Id = c.Id,
                LastUpdate = c.LastUpdate,
                Name = c.Name
            });
        }

        public async Task<IEnumerable<NameWithDescriptionResponseDto>> GetCategoriesNameWithDescriptionAsync()
        {
            var categoriesEntity = await _categoryRepository.GetAllCategoriesAsync();
            return categoriesEntity.Select(c => new NameWithDescriptionResponseDto()
            {
                CreateDate = c.CreateDate,
                Id = c.Id,
                LastUpdate = c.LastUpdate,
                NameWithDescription = $"{c.Name} - {c.Description}"
            });
        }
    }
}
