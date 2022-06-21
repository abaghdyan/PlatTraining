namespace PlatTraining.Data.TenantUnit.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Paid { get; set; }
        public bool IsFinished { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Tax { get; set; }
        public string OwnerId { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
