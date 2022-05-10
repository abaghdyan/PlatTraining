namespace PlatTraining.TenantData.Entities
{
    public class Tenant : MasterBaseEntity
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
