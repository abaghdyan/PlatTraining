using Microsoft.Data.SqlClient;
using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Data.Helpers
{
    public static class ConnectionHelper
    {
        public static SqlConnectionStringBuilder GetConnectionBuilder(string key, TenantConnectionInfo connectionInfo)
        {
            var dataSource = SecurityHelper.Decrypt(key, connectionInfo.DataSource);
            var initialCatalog = SecurityHelper.Decrypt(key, connectionInfo.InitialCatalog);
            var userId = connectionInfo.UserId == null ? "" : SecurityHelper.Decrypt(key, connectionInfo.UserId);
            var password = connectionInfo.Password == null ? "" : SecurityHelper.Decrypt(key, connectionInfo.Password);

            return new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                InitialCatalog = initialCatalog,
                Encrypt = connectionInfo.Encrypt,
                TrustServerCertificate = connectionInfo.TrustServerCertificate,
                UserID = userId,
                Password = password,
                LoadBalanceTimeout = connectionInfo.LoadBalanceTimeoutInSec,
                Pooling = connectionInfo.Pooling,
                MinPoolSize = connectionInfo.MinPoolSize,
                MaxPoolSize = connectionInfo.MaxPoolSize,
            };
        }
    }
}
