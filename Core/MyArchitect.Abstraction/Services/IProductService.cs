using MyArchitect.RequestResponseModels.Product.GetAllProducts;

namespace MyArchitect.Abstraction.Services
{
    public interface IProductService
    {
        Task<IEnumerable<GetAllProductDto>> GetAllProductAsync();
        Task<GetAllProductDto> GetProductByIdAsync(int id);
    }
}
