using Microsoft.Data.SqlClient;

namespace PlatTraining.Data.Models
{
    public class TenantInfo
    {
        public string TenantId { get; private set; }
        public string TenantName { get; private set; }
        public string ConnectionString { get; private set; }
        public bool Initilized { get; private set; }

        public TenantInfo()
        {
            TenantId = string.Empty;
            TenantName = string.Empty;
            ConnectionString = nameof(string.Empty);
            Initilized = false;
        }

        internal TenantInfo InitiateForScope(string tenantId, string tenantName, SqlConnectionStringBuilder connectionBuilder)
        {
            TenantId = tenantId;
            TenantName = tenantName;
            ConnectionString = connectionBuilder.ToString();
            Initilized = true;
            return this;
        }
    }
}
