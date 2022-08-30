using Dapper;
using DbContextHelper.Common;
using System.Data;
using System.Data.SqlClient;

namespace DbContextHelper.ReadDbContext
{
    public class AppReadDbContext : AppDbContext, IAppReadDbContext
    {
        public AppReadDbContext(IAppSettings appSettings) : base(appSettings)
        {

        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string stringQuerry, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150) {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                return await conn.QueryAsync<T>(stringQuerry, param, transaction, commandTimeout, CommandType.Text);
            }
        }

       

        public async Task<IEnumerable<T>> QueryAsync<T>(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150) {
            using (SqlConnection conn = GetConnection()) {
                conn.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                return await conn.QueryAsync<T>(stringQuerry, dynamicParameters, transaction, commandTimeout, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                if(parameters == null) parameters = new DynamicParameters();
                return await conn.QueryAsync<T>(stringQuerry, parameters, transaction, commandTimeout, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<T>> QueryStoreAsync<T>(string procedureName, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            using (SqlConnection conn = GetConnection()) {
                return await conn.QueryAsync<T>(procedureName, param , transaction, commandTimeout, CommandType.StoredProcedure);
            }
            
        }

        public async Task<IEnumerable<T>> QueryStoreAsync<T>(string procedureName, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150) {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                DynamicParameters dynamicParameters = new DynamicParameters(dictionary);
                return await conn.QueryAsync<T>(procedureName, dynamicParameters, transaction, commandTimeout, commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<IEnumerable<T>> QueryStoreAsync<T>(string procedureName, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                if (parameters == null) parameters = new DynamicParameters();
                return await conn.QueryAsync<T>(procedureName, parameters, transaction, commandTimeout, commandType: CommandType.StoredProcedure);
            }
        }


        public DataTable QueryAsync(string stringQuerry, object param = null, IDbTransaction transaction = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(stringQuerry, conn, (SqlTransaction)transaction))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(param);
                conn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable QueryAsync(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(stringQuerry, conn, (SqlTransaction)transaction))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new DynamicParameters(dictionary));
                conn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable QueryAsync(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(stringQuerry, conn, (SqlTransaction)transaction))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                if(parameters != null) cmd.Parameters.Add(parameters);
                conn.Open();
                da.Fill(dt);
                return dt;
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string stringQuerry, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150) {
            using (SqlConnection conn = GetConnection())
                return await conn.QueryFirstOrDefaultAsync<T>(stringQuerry, param, transaction, commandTimeout, CommandType.Text);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string stringQuerry, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150) {
            using (SqlConnection conn = GetConnection())
            {
                DynamicParameters dynamicParameters = new DynamicParameters(dictionary);
                return await conn.QueryFirstOrDefaultAsync<T>(stringQuerry, dynamicParameters, transaction, commandTimeout, commandType: CommandType.Text);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string stringQuerry, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            using (SqlConnection conn = GetConnection())
            {
                if (parameters == null) parameters = new DynamicParameters();
                return await conn.QueryFirstOrDefaultAsync<T>(stringQuerry, parameters, transaction, commandTimeout, commandType: CommandType.Text);
            }
        }


        public async Task<T> QueryFirstOrDefaultStoreAsync<T>(string procedureName, object param = null, IDbTransaction transaction = null, int? commandTimeout = 150) {
            using (SqlConnection conn = GetConnection())
                return await conn.QueryFirstOrDefaultAsync<T>(procedureName, param, transaction, commandTimeout, CommandType.StoredProcedure);
        }

        public async Task<T> QueryFirstOrDefaultStoreAsync<T>(string procedureName, Dictionary<string, string> dictionary = null, IDbTransaction transaction = null, int? commandTimeout = 150) {
            using (SqlConnection conn = GetConnection())
            {
                DynamicParameters dynamicParameters = new DynamicParameters(dictionary);
                return await conn.QueryFirstOrDefaultAsync<T>(procedureName, dynamicParameters, transaction, commandTimeout, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<T> QueryFirstOrDefaultStoreAsync<T>(string procedureName, DynamicParameters parameters = null, IDbTransaction transaction = null, int? commandTimeout = 150)
        {
            using (SqlConnection conn = GetConnection())
            {
                if (parameters == null) parameters = new DynamicParameters();
                return await conn.QueryFirstOrDefaultAsync<T>(procedureName, parameters, transaction, commandTimeout, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
