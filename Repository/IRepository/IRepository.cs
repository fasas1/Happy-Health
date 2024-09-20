using Happy_Health.Models;
using System.Linq.Expressions;

namespace Happy_Health.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string? includeProperties = null);
        Task CreateAsync(T entity);
        //void Update(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
