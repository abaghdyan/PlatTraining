namespace PlatTraining.Data.TenantUnit.Entities
{
    public class SomeTenantData
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public IndexState State { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
