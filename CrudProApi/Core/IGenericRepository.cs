namespace CrudProApi.Core
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> AllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
