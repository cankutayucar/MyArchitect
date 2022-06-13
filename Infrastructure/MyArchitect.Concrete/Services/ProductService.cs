using AutoMapper;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Abstraction.Services;
using MyArchitect.RequestResponseModels.Product.GetAllProducts;

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
    }
}
