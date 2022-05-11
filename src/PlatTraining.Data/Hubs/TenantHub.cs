using Microsoft.Data.SqlClient;

namespace PlatTraining.Data.Hubs
{
    public class TenantHub
    {
        public string TenantId { get; private set; }
        public string TenantName { get; private set; }
        public string ConnectionString { get; private set; }

        public TenantHub()
        {
            TenantId = string.Empty;
            TenantName = string.Empty;
            ConnectionString = Guid.NewGuid().ToString();
        }

        internal TenantHub InitiateForScope(string tenantId, string tenantName, SqlConnectionStringBuilder connectionBuilder)
        {
            TenantId = tenantId;
            TenantName = tenantName;
            ConnectionString = connectionBuilder.ToString();
            return this;
        }
    }
}
