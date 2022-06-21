namespace PlatTraining.Data.MasterUnit.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccessLevel { get; set; }
        public ICollection<RolePermission> Permissions { get; set; }
        public ICollection<RoleUser> Users { get; set; }
    }
}
