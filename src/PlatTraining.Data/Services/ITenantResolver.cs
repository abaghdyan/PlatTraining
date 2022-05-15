namespace PlatTraining.Data.Services
{
    public interface ITenantResolver
    {
        Task InitiateTenantInfo(string tenantId);
    }
}
