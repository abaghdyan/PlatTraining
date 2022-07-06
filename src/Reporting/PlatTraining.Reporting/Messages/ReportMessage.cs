namespace PlatTraining.Reporting.Messages
{
    public class ReportMessage
    {
        public string ReportType { get; set; }
        public string Body { get; set; }
        public string QueryString { get; set; }
        public DateTime? Date { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }
}
