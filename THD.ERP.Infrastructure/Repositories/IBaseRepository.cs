namespace THD.ERP.Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        
        Task<T> GetByIdAsync(long id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(long id);

    }
}
