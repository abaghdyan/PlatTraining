using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlatTraining.Reporting.Entities
{
    public class Report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]
        public string ReportType { get; set; }
        public string Body { get; set; }
        public string QueryString { get; set; }
        public DateTime? Date { get; set; } = DateTime.UtcNow;
        public string Url { get; set; }
        public int UserId { get; set; }
    }
}
