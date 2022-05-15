using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.Helpers;
using PlatTraining.Data.MasterUnit;
using PlatTraining.Data.Models;

namespace PlatTraining.Data.Services
{
    public class TenantResolver : ITenantResolver
    {
        private readonly TenantInfo _tenantInfo;
        private readonly PlatMasterDbContext _masterDbContext;

        public TenantResolver(TenantInfo tenantInfo, PlatMasterDbContext masterDbContext)
        {
            _tenantInfo = tenantInfo;
            _masterDbContext = masterDbContext;
        }

        public async Task InitiateTenantInfo(string tenantId)
        {
            var tenant = await _masterDbContext.Tenants
                .Include(t => t.TenantConnectionInfo)
                .FirstOrDefaultAsync(t => t.Id == tenantId);

            if (tenant == null)
            {
                throw new ArgumentNullException($"Tenant with {tenantId} Id was not found.");
            }

            _tenantInfo.InitiateForScope(tenant.Id, tenant.Name,
                ConnectionHelper.GetConnectionBuilder(tenant.TenantConnectionInfo));
        }
    }
}
