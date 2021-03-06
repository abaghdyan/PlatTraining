namespace PlatTraining.Data.MasterUnit.Entities
{
    public class TenantConnectionInfo
    {
        public string Id { get; set; }
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int LoadBalanceTimeoutInSec { get; set; }
        public int MinPoolSize { get; set; }
        public int MaxPoolSize { get; set; }
        public bool Pooling { get; set; }
        public bool Encrypt { get; set; }
        public bool TrustServerCertificate { get; set; }
        public string TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
