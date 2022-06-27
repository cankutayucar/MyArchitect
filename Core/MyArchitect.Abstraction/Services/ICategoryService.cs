using MyArchitect.RequestResponseModels;
using MyArchitect.RequestResponseModels.Category.CreateCategory;
using MyArchitect.RequestResponseModels.Category.GetAllCategories;
using MyArchitect.RequestResponseModels.Category.GetCategoriesNameWithDescription;
using MyArchitect.RequestResponseModels.Category.UpdateCategory;

namespace MyArchitect.Abstraction.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();
        Task<IEnumerable<NameWithDescriptionResponseDto>> GetCategoriesNameWithDescriptionAsync();
        Task<CategoryResponseDto> GetCategoryByIdAsync(int id);
        Task<Response<int>> CreateCategoryAsync(CreateCategoryDto dto);
        Task<Response<bool>> UpdateCategoryAsync(object id, UpdateCategoryDto dto);
        Task<Response<bool>> DeleteCategoryAsync(object id);
    }
}
