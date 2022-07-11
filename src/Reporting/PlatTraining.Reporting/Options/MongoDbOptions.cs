namespace PlatTraining.Reporting.Options
{
    public class MongoDbOptions
    {
        public const string Section = "MongoDbOptions";

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ReportsCollectionName { get; set; }
    }
}
