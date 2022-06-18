using AutoMapper;
using MyArchitect.Domain.Entities;
using MyArchitect.RequestResponseModels.Category.CreateCategory;
using MyArchitect.RequestResponseModels.Category.GetAllCategories;
using MyArchitect.RequestResponseModels.Category.GetCategoriesNameWithDescription;
using MyArchitect.RequestResponseModels.Category.UpdateCategory;

namespace MyArchitect.Concrete.Mappings
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryResponseDto>().ReverseMap();
            CreateMap<Category, NameWithDescriptionResponseDto>()
                .ForMember(dto => dto.NameWithDescription,
                    m => m.MapFrom(entity => entity.Name + " - " + entity.Description));
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
