using Microsoft.EntityFrameworkCore;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Domain.Entities;
using MyArchitect.Persistence;

namespace MyArchitect.Concrete.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OnionContext  _context;

        public CategoryRepository(OnionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id) ?? new Category();
        }
    }
}
