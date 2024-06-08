
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using SpinxTask.Infrastructure.Data;
using System.Linq.Expressions;
using SpinxTask.Core.Interfaces;

namespace SpinxTask.Infrastructure.Presistence
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        private DbSet<T> _entity;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>(); // should be any type of dbtable class
        }

        private IQueryable<T> HandleIncludes(
            IQueryable<T> query,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool IgnoreGlobalFilters = false,
            Expression<Func<T, T>> select = null,
            bool disableTracking = true
         )
        {
            if (IgnoreGlobalFilters)
                query = query.IgnoreQueryFilters();
            if (disableTracking)
                query.AsNoTracking();
            if (include != null)
                query = include(query);

            if (select != null)
                return query.Select(select);
            return query;
        }


        public async Task AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task<T> GetById(string id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync(
            Expression<Func<T, T>> selector = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true,
            int? take = null,
            int? skip = null
            )
        {
            IQueryable<T> query = _entity;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (selector != null)
                query = query.Select(selector);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        



        public void DeleteAsync(T entity)
        {
            _entity.Remove(entity);
        }
        public async Task UpdateAsync(T entity)
        {
            _entity.Update(entity);
        }

        public async Task<T> FindAsync(
            Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool IgnoreGlobalFilters = false,
            bool disableTracking = true,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null

        )
        {
            return await HandleIncludes(_entity, include, IgnoreGlobalFilters, disableTracking:disableTracking).SingleOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> FindAllAsync(
            Expression<Func<T, bool>> expression,
            int? take = null,
            int? skip = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool IgnoreGlobalFilters = false
            )
        {
            var query = HandleIncludes(_entity, include, IgnoreGlobalFilters).Where(expression);


            if (take.HasValue)
                query = query.Take(take.Value);
            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<int> GetCount(
            Expression<Func<T, bool>>? expression = null
            )
        {
            if (expression == null)
                return await _entity.AsNoTracking().CountAsync();
            return await _entity.AsNoTracking().Where(expression).CountAsync();
        }

        
    }
}
