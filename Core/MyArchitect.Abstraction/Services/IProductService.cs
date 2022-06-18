using MyArchitect.RequestResponseModels.Product.CreateProduct;
using MyArchitect.RequestResponseModels.Product.GetAllProducts;
using MyArchitect.RequestResponseModels.Product.UpdateProduct;

namespace MyArchitect.Abstraction.Services
{
    public interface IProductService
    {
        Task<IEnumerable<GetAllProductDto>> GetAllProductAsync();
        Task<GetAllProductDto> GetProductByIdAsync(int id);
        Task<int> InsertProductAsync(CreateProductDto dto);
        Task<bool> UpdateProductAsync(object id, UpdateProductDto dto);
        Task<bool> DeleteProductAsync(object id);
    }
}
