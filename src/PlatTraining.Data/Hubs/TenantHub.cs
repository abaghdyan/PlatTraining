namespace PlatTraining.Data.Hubs
{
    public class TenantHub
    {
        public string TenantId { get; set; }
        public string TenantName { get; set; }
        public string ConnectionString { get; set; }

        internal void InitiateForScope(string tenantId, string tenantName, string connectionString)
        {
            TenantId = tenantId;
            TenantName = tenantName;
            ConnectionString = connectionString;
        }
    }
}
