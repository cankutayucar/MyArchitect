using MyArchitect.Abstraction.Repositories;
using MyArchitect.Abstraction.Services;
using MyArchitect.RequestResponseModels.Product.GetAllProducts;

namespace MyArchitect.Concrete.Services
{
    public class ProductService : IProductService
    {
        private readonly  IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetAllProductDto>> GetAllProductAsync()
        {
            var productsEntity = await _repository.GetAllProductsAsync();
            return productsEntity.Select(p => new GetAllProductDto
            {
                NAME = p.Name,
                CategoryId = p.CategoryId,
                CreateDate = p.CreateDate,
                Id = p.Id,
                LastUpdate = p.LastUpdate,
                UnitInStock = p.UnitInStock
            });
        }
    }
}
