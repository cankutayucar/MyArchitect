using MyArchitect.RequestResponseModels.Category.GetAllCategories;
using MyArchitect.RequestResponseModels.Category.GetCategoriesNameWithDescription;

namespace MyArchitect.Abstraction.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();
        Task<IEnumerable<NameWithDescriptionResponseDto>> GetCategoriesNameWithDescriptionAsync();
        Task<CategoryResponseDto> GetCategoryByIdAsync(int id);
    }
}
