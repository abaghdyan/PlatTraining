﻿using Microsoft.Data.SqlClient;
using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Data.Helpers
{
    public static class ConnectionHelper
    {
        public static SqlConnectionStringBuilder GetConnectionBuilder(TenantConnectionInfo connectionInfo)
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = connectionInfo.DataSource,
                InitialCatalog = connectionInfo.InitialCatalog,
                Encrypt = connectionInfo.Encrypt,
                TrustServerCertificate = connectionInfo.TrustServerCertificate,
                UserID = connectionInfo.UserId,
                Password = connectionInfo.Password
            };
        }
    }
}