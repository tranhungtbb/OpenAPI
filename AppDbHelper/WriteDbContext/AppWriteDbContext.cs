using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DbContextHelper.WriteDbContext
{
    public class AppWriteDbContext : AppDbContext, IAppWriteDbContext
    {
        public AppWriteDbContext(IAppSettings appSettings) : base(appSettings)
        {
        }

        public async Task ExecuteAsync(string stringQuerry, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            await GetConnection().ExecuteAsync(stringQuerry, param, transaction, commandTimeout, CommandType.Text);
        }

        public async Task ExecuteAsync(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            await GetConnection().ExecuteAsync(stringQuerry, dictionary, transaction, commandTimeout, CommandType.Text);
        }

        public async Task ExecuteAsync(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            await GetConnection().ExecuteAsync(stringQuerry, parameters, transaction, commandTimeout, CommandType.Text);
        }

        public async Task ExecuteStoreAsync(string procedureName, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            await GetConnection().ExecuteAsync(procedureName, param, transaction, commandTimeout, CommandType.StoredProcedure);
        }

        public async Task ExecuteStoreAsync(string procedureName, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            await GetConnection().ExecuteAsync(procedureName, dictionary, transaction, commandTimeout, CommandType.StoredProcedure);
        }

        public async Task ExecuteStoreAsync(string procedureName, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            await GetConnection().ExecuteAsync(procedureName, parameters, transaction, commandTimeout, CommandType.StoredProcedure);
        }




        public async Task<DbDataReader> ExecuteReaderAsync(string stringQuerry, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            return await GetConnection().ExecuteReaderAsync(stringQuerry, param, transaction, commandTimeout, CommandType.Text);
        }

        public async Task<DbDataReader> ExecuteReaderAsync(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            return await GetConnection().ExecuteReaderAsync(stringQuerry, dictionary, transaction, commandTimeout, CommandType.Text);
        }

        public async Task<DbDataReader> ExecuteReaderAsync(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            return await GetConnection().ExecuteReaderAsync(stringQuerry, parameters, transaction, commandTimeout, CommandType.Text);
        }

        public async Task<T> ExecuteScalarAsync<T>(string stringQuerry, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            return await GetConnection().ExecuteScalarAsync<T>(stringQuerry, param, transaction, commandTimeout, CommandType.Text);
        }

        public async Task<T> ExecuteScalarAsync<T>(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            return await GetConnection().ExecuteScalarAsync<T>(stringQuerry, dictionary, transaction, commandTimeout, CommandType.Text);
        }

        public async Task<T> ExecuteScalarAsync<T>(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            return await GetConnection().ExecuteScalarAsync<T>(stringQuerry, parameters, transaction, commandTimeout, CommandType.Text);
        }

        public async Task<T> ExecuteScalarStoreAsync<T>(string stringQuerry, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            return await GetConnection().ExecuteScalarAsync<T>(stringQuerry, param, transaction, commandTimeout, CommandType.StoredProcedure);
        }

        public async Task<T> ExecuteScalarStoreAsync<T>(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            return await GetConnection().ExecuteScalarAsync<T>(stringQuerry, dictionary, transaction, commandTimeout, CommandType.StoredProcedure);
        }

        public async Task<T> ExecuteScalarStoreAsync<T>(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            return await GetConnection().ExecuteScalarAsync<T>(stringQuerry, parameters, transaction, commandTimeout, CommandType.StoredProcedure);
        }

    }
}
