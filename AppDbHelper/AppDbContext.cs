using System;
using System.Collections.Generic;
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
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Rollback();
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

        public AppDbContext()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public SqlConnection GetConnection()
        {
            this._sqlConnection = new SqlConnection(_appSettings.GetConnectstring());
            return this._sqlConnection;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            this._dbTransaction = await this._sqlConnection.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await this._dbTransaction.CommitAsync(cancellationToken);
        }

        public void Rollback()
        {
            this._dbTransaction.Rollback();
        }
    }
}
