using Dapper;
using System.Data;

namespace DbContextHelper.ReadDbContext
{
    public interface IAppReadDbContext : IAppDbContext
    {
        Task<IEnumerable<T>> QueryAsync<T>(string stringQuerry, object param = null, int? commandTimeout = 150);

        Task<IEnumerable<T>> QueryAsync<T>(string stringQuerry, Dictionary<string, string> dictionary = null, int? commandTimeout = 150);

        Task<IEnumerable<T>> QueryAsync<T>(string stringQuerry, DynamicParameters parameters = null, int? commandTimeout = 150);

        Task<IEnumerable<T>> QueryStoreAsync<T>(string procedureName, object param = null, int? commandTimeout = 150);

        Task<IEnumerable<T>> QueryStoreAsync<T>(string procedureName, Dictionary<string, string> dictionary = null, int? commandTimeout = 150);

        Task<IEnumerable<T>> QueryStoreAsync<T>(string procedureName, DynamicParameters parameters = null, int? commandTimeout = 150);

        DataTable QueryAsync(string stringQuerry, object param = null, IDbTransaction transaction = null);

        DataTable QueryAsync(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null);

        DataTable QueryAsync(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null);


        Task<T> QueryFirstOrDefaultAsync<T>(string stringQuerry, object param = null, int? commandTimeout = 150);

        Task<T> QueryFirstOrDefaultAsync<T>(string stringQuerry, Dictionary<string, string> dictionary = null, int? commandTimeout = 150);

        Task<T> QueryFirstOrDefaultAsync<T>(string stringQuerry, DynamicParameters parameters = null, int? commandTimeout = 150);

        Task<T> QueryFirstOrDefaultStoreAsync<T>(string procedureName, object param = null, int? commandTimeout = 150);

        Task<T> QueryFirstOrDefaultStoreAsync<T>(string procedureName, Dictionary<string, string> dictionary = null, int? commandTimeout = 150);

        Task<T> QueryFirstOrDefaultStoreAsync<T>(string procedureName, DynamicParameters parameters = null, int? commandTimeout = 150);

    }
}
