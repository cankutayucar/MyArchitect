using System.Linq.Expressions;

namespace MyArchitect.Abstraction.Repositories
{
    public interface IRepository<T>
    where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(object id);
        Task<IEnumerable<T>> GeByFilterAsync(Expression<Func<T, bool>> filter);
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(object id);
    }
}
