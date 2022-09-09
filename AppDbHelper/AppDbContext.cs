using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextHelper
{
    public interface IAppDbContext
    {
        SqlConnection GetConnection();
        DbTransaction BeginTransaction();
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync();
    }

    public class AppDbContext : IAppDbContext
    {
        private SqlConnection _sqlConnection;
        private DbTransaction _dbTransaction;

        private readonly IAppSettings _appSettings;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AppDbContext(IAppSettings appSettings) {
            this._appSettings = appSettings;

        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public SqlConnection GetConnection()
        {
            if (this._sqlConnection == null)
            {
                this._sqlConnection = new SqlConnection(_appSettings.GetConnectstring());
            }
            if (this._sqlConnection.State != ConnectionState.Open)
            {
                this._sqlConnection.Close();
                this._sqlConnection.Open();
            }
            return this._sqlConnection;
        }

        public DbTransaction BeginTransaction()
        {
            this._dbTransaction = this._sqlConnection.BeginTransaction();
            return this._dbTransaction;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await this._dbTransaction.CommitAsync(cancellationToken);
        }

        public async Task RollbackAsync()
        {
            await this._dbTransaction.RollbackAsync();
        }
    }
}
