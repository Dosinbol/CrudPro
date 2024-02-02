
using CrudProApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudProApi.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ProjectContext _context;
        internal DbSet<T> _set;
        protected readonly ILogger _logger;
        public GenericRepository(ProjectContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _set = _context.Set<T>();
        }
        public virtual async Task<bool> AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _set.Remove(entity);
            return true;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _set.Update(entity);
            return true;
        }
    }
}
