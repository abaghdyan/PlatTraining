namespace PlatTraining.Data.MasterUnit.Entities
{
    public class RoleUser
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int GlobalUserId { get; set; }
        public GlobalUser User { get; set; }
    }
}
