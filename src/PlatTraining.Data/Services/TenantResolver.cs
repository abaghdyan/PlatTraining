using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.DbContexts;
using PlatTraining.Data.Hubs;

namespace PlatTraining.Data.Services
{
    public class TenantResolver : ITenantResolver
    {
        private readonly TenantHub _tenantHub;
        private readonly PlatMasterDbContext _masterDbContext;
        public TenantResolver(TenantHub tenantHub, PlatMasterDbContext masterDbContext)
        {
            _tenantHub = tenantHub;
            _masterDbContext = masterDbContext;
        }

        public async Task InitiateTenantHub(string tenantId)
        {
            var tenant = await _masterDbContext.Tenants.FirstOrDefaultAsync(t => t.Id == tenantId);
            _tenantHub.InitiateForScope(tenant.Id, tenant.Name, tenant.ConnectionString);
        }
    }
}
