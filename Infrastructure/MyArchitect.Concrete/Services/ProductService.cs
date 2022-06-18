using AutoMapper;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Abstraction.Services;
using MyArchitect.Domain.Entities;
using MyArchitect.RequestResponseModels.Product.CreateProduct;
using MyArchitect.RequestResponseModels.Product.GetAllProducts;
using MyArchitect.RequestResponseModels.Product.UpdateProduct;

namespace MyArchitect.Concrete.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        public async Task<int> InsertProductAsync(CreateProductDto dto)
        {
            return (await _repository.InsertAsync(_mapper.Map<Product>(dto))) == null ? 0 : 1;
        }

        public async Task<bool> UpdateProductAsync(object id, UpdateProductDto dto)
        {
            var product = await _repository.GetAsync(id);
            if (product == null)
                return false;
            return await _repository.UpdateAsync(_mapper.Map(dto, product));
        }

        public async Task<bool> DeleteProductAsync(object id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
