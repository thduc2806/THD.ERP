namespace THD.ERP.Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string sql);

        Task<T> GetByIdAsync(string sql, object parameters);

        Task<int> ExecuteAsync(string sql, object parameters);

        Task<T> ExecuteScalarAsync(string sql, object parameters);

    }
}
