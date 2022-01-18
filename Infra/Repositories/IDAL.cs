namespace Infra.Repositories;
    public interface IDAL<T> where T : class
    {
        Task<T?> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> Remove(T entity);

    }
