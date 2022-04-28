namespace PlatTraining.Options
{
    public class EnvironmentOptions
    {
        public const string Section = "EnvironmentOptions";
        public bool IsInsertRequestLog { get; set; }
        public string LogBaseUrl { get; set; }
    }
}
