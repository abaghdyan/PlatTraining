namespace PlatTraining.Services.Contracts
{
    public class TransientService : ITransientService
    {
        private readonly IPlatIndexService _platIndexService;

        public TransientService(IPlatIndexService platIndexService)
        {
            _platIndexService = platIndexService;
        }

        public string GetGuidTransient()
        {
            return _platIndexService.GetGuid();
        }
    }
}
