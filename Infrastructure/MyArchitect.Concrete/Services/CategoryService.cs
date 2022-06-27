using System.Net.Http.Headers;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Abstraction.Services;
using MyArchitect.Domain.Entities;
using MyArchitect.RequestResponseModels;
using MyArchitect.RequestResponseModels.Category.CreateCategory;
using MyArchitect.RequestResponseModels.Category.GetAllCategories;
using MyArchitect.RequestResponseModels.Category.GetCategoriesNameWithDescription;
using MyArchitect.RequestResponseModels.Category.UpdateCategory;
using MyArchitect.Utils;

namespace MyArchitect.Concrete.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCategoryDto> _validator;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IValidator<CreateCategoryDto> validator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryResponseDto>>(categoriesEntity);
        }

        public async Task<IEnumerable<NameWithDescriptionResponseDto>> GetCategoriesNameWithDescriptionAsync()
        {
            var categoriesEntity = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<NameWithDescriptionResponseDto>>(categoriesEntity);
        }

        public async Task<CategoryResponseDto> GetCategoryByIdAsync(int id)
        {
            return _mapper.Map<CategoryResponseDto>(await _categoryRepository.GetAsync(id));
        }

        public async Task<Response<int>> CreateCategoryAsync(CreateCategoryDto dto)
        {
            var result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
                return new Response<int>() { Success = false, Message = result.Errors.ParsValidationErrors() };
            var categoryEntity = _mapper.Map<Category>(dto);
            var insertResult = await _categoryRepository.InsertAsync(categoryEntity);
            if (insertResult)
            {
                return new Response<int>()
                    { Result = categoryEntity.Id, Success = true, Message = "Kategori başarıyla eklendi" };
            }
            else
            {
                return new Response<int>()
                    { Result = categoryEntity.Id, Success = false, Message = "Kategori eklenemedi" };
            }
        }

        public async Task<Response<bool>> UpdateCategoryAsync(object id, UpdateCategoryDto dto)
        {
            var result = await _categoryRepository.GetAsync(id);
            if (result == null)
            {
                return false;
            }
            return await _categoryRepository.UpdateAsync(_mapper.Map(dto, result));
        }

        public async Task<Response<bool>> DeleteCategoryAsync(object id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }
    }
}
