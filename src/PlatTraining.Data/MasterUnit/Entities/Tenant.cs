using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Data.MasterUnit.Entities
{
    public class Tenant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Data { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public TenantConnectionInfo TenantConnectionInfo { get; set; }
    }
}
