using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace SpinxTask.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        
        Task<List<T>> GetAllAsync(
            /*Expression<Func<T, bool>> predicate = null,*/
            Expression<Func<T, T>> selector = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true,
            int? take = null,
            int? skip = null
            );
        Task<T> GetById(string id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        void DeleteAsync(T entity);

        Task<T> FindAsync(
            Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool IgnoreGlobalFilters = false,
            bool disableTracking = true,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
            );
        Task<IEnumerable<T>> FindAllAsync(
            Expression<Func<T, bool>> expression,
            int? take = null,
            int? skip = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool IgnoreGlobalFilters = false
         );
        Task<int> GetCount(Expression<Func<T, bool>>? expression = null);
    }
}
