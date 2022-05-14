using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.DbContexts;
using PlatTraining.Data.Helpers;
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
            var tenant = await _masterDbContext.Tenants
                .Include(t => t.TenantConnectionInfo)
                .FirstOrDefaultAsync(t => t.Id == tenantId);

            if (tenant == null)
            {
                throw new ArgumentNullException($"Tenant with {tenantId} Id was not found.");
            }

            _tenantHub.InitiateForScope(tenant.Id, tenant.Name,
                ConnectionHelper.GetConnectionBuilder(tenant.TenantConnectionInfo));
        }
    }
}
