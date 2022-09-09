using Dapper;
using System.Data;
using System.Data.Common;

namespace DbContextHelper.WriteDbContext
{
    public interface IAppWriteDbContext : IAppDbContext
    {
        Task ExecuteAsync(string stringQuerry, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150);

        Task ExecuteAsync(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150);

        Task ExecuteAsync(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150);


        Task ExecuteStoreAsync(string procedureName, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150);

        Task ExecuteStoreAsync(string procedureName, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150);

        Task ExecuteStoreAsync(string procedureName, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150);


        Task<DbDataReader> ExecuteReaderAsync(string stringQuerry, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150);

        Task<DbDataReader> ExecuteReaderAsync(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150);

        Task<DbDataReader> ExecuteReaderAsync(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150);



        Task<T> ExecuteScalarAsync<T>(string stringQuerry, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150);

        Task<T> ExecuteScalarAsync<T>(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150);

        Task<T> ExecuteScalarAsync<T>(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150);

        Task<T> ExecuteScalarStoreAsync<T>(string stringQuerry, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150);

        Task<T> ExecuteScalarStoreAsync<T>(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150);

        Task<T> ExecuteScalarStoreAsync<T>(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150);

    }
}
