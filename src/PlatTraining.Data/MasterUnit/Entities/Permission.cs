namespace PlatTraining.Data.MasterUnit.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccessLevel { get; set; }
        public ICollection<RolePermission> Roles { get; set; }
    }
}
