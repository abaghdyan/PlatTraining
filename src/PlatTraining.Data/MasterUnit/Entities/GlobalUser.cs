namespace PlatTraining.Data.MasterUnit.Entities
{
    public class GlobalUser
    {
        public long Id { get; set; }
        public string? TenantId { get; set; }
        public int LocalId { get; set; }
        public bool Active { get; set; }
        public bool Removed { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsNeedSendInvitation { get; set; }
        public DateTime? PasswordExpiration { get; set; }
        public ICollection<RoleUser> Roles { get; set; }
    }
}
