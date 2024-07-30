using Dapper;
using System.Data;

namespace THD.ERP.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IDbConnection _connection;

        protected BaseRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        protected IDbConnection CreateConnection()
        {
            return _connection;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string sql)
        {

            return await _connection.QueryAsync<T>(sql);
        }

        public async Task<T> GetByIdAsync(string sql, object parameters)
        {
            return await _connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
        }

        public async Task<int> ExecuteAsync(string sql, object parameters)
        {
            return await _connection.ExecuteAsync(sql, parameters);
        }

        public async Task<T> ExecuteScalarAsync(string sql, object parameters)
        {
            return await _connection.ExecuteScalarAsync<T>(sql, parameters);
        }
    }
}
