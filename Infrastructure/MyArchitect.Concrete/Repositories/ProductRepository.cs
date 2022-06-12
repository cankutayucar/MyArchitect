using Microsoft.EntityFrameworkCore;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Domain.Entities;
using MyArchitect.Persistence;

namespace MyArchitect.Concrete.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnionContext _context;

        public ProductRepository(OnionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
