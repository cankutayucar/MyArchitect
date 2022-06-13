using Microsoft.EntityFrameworkCore;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Persistence;
using System.Linq.Expressions;

namespace MyArchitect.Concrete.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly OnionContext _context;

        public Repository(OnionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GeByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<bool> InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(object id)
        {
            var item = await _context.Set<T>().FindAsync(id);
            if (item == null) return false;
            _context.Remove(item);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
