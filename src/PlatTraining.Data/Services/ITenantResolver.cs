namespace PlatTraining.Data.Services
{
    public interface ITenantResolver
    {
        Task InitiateTenantHub(string tenantId);
    }
}
