using MyArchitect.RequestResponseModels;
using MyArchitect.RequestResponseModels.Product.CreateProduct;
using MyArchitect.RequestResponseModels.Product.GetAllProducts;
using MyArchitect.RequestResponseModels.Product.UpdateProduct;

namespace MyArchitect.Abstraction.Services
{
    public interface IProductService
    {
        Task<IEnumerable<GetAllProductDto>> GetAllProductAsync();
        Task<GetAllProductDto> GetProductByIdAsync(int id);
        Task<Response<int>> InsertProductAsync(CreateProductDto dto);
        Task<Response<bool>> UpdateProductAsync(object id, UpdateProductDto dto);
        Task<Response<bool>> DeleteProductAsync(object id);
    }
}
