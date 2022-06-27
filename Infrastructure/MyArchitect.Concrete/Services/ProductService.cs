using AutoMapper;
using FluentValidation;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Abstraction.Services;
using MyArchitect.Domain.Entities;
using MyArchitect.RequestResponseModels;
using MyArchitect.RequestResponseModels.Product.CreateProduct;
using MyArchitect.RequestResponseModels.Product.GetAllProducts;
using MyArchitect.RequestResponseModels.Product.UpdateProduct;

namespace MyArchitect.Concrete.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductDto> _validator;
        public ProductService(IProductRepository repository, IMapper mapper, IValidator<CreateProductDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllProductDto>> GetAllProductAsync()
        {
            var productsEntity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllProductDto>>(productsEntity);
        }

        public async Task<GetAllProductDto> GetProductByIdAsync(int id)
        {
            return _mapper.Map<GetAllProductDto>(await _repository.GetAsync(id));
        }

        public async Task<Response<int>> InsertProductAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            var result = await _repository.InsertAsync(product);
            if (result)
            {
                return new Response<int>() { Success = true, Message = "ürün basarıyla eklendi",Result = product.Id};
            }
            else
            {
                return new Response<int>() { Success = false, Message = "ürün eklenemedi" };
            }
        }

        public async Task<Response<bool>> UpdateProductAsync(object id, UpdateProductDto dto)
        {
            var product = await _repository.GetAsync(id);

            if (product == null)
                return new Response<bool>() { Success = false, Message = "ürün bulunamadı" };

            var result = await _repository.UpdateAsync(_mapper.Map(dto, product));

            if (result)
            {
                return new Response<bool>() { Success = true, Message = "ürün basarıyla güncellendi" };
            }
            else
            {
                return new Response<bool>() { Success = false, Message = "ürün güncellenemedi" };
            }
        }

        public async Task<Response<bool>> DeleteProductAsync(object id)
        {
            var result =  await _repository.DeleteAsync(id);
            if (result)
            {
                return new Response<bool>() { Success = true, Message = "ürün basarıyla silindi" };
            }
            else
            {
                return new Response<bool>() { Success = false, Message = "ürün silinemedi" };
            }
        }
    }
}
