namespace PlatTraining.Data.TenantUnit.Entities
{
    public class EmailHistory
    {
        public int Id { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string Body { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime Date { get; set; }
    }
}
