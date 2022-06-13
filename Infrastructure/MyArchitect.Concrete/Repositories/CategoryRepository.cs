using Microsoft.EntityFrameworkCore;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Domain.Entities;
using MyArchitect.Persistence;

namespace MyArchitect.Concrete.Repositories
{
    public class CategoryRepository :Repository<Category>, ICategoryRepository
    {

        public CategoryRepository(OnionContext context) : base(context)
        {
        }
    }
}
