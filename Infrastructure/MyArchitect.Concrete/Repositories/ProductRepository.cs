using Microsoft.EntityFrameworkCore;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Domain.Entities;
using MyArchitect.Persistence;

namespace MyArchitect.Concrete.Repositories
{
    public class ProductRepository :Repository<Product>,IProductRepository
    {
        public ProductRepository(OnionContext context) : base(context)
        {
        }
    }
}
