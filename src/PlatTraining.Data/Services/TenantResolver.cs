using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlatTraining.Data.Helpers;
using PlatTraining.Data.MasterUnit;
using PlatTraining.Data.Models;
using PlatTraining.Data.Options;

namespace PlatTraining.Data.Services
{
    public class TenantResolver : ITenantResolver
    {
        private readonly TenantInfo _tenantInfo;
        private readonly MasterDbContext _masterDbContext;
        private readonly EncryptionOptions _options;

        public TenantResolver(TenantInfo tenantInfo,
            MasterDbContext masterDbContext,
            IOptions<EncryptionOptions> options)
        {
            _options = options.Value;
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

            var connectionBuilder = ConnectionHelper.GetConnectionBuilder(_options.Key, tenant.TenantConnectionInfo);
            _tenantInfo.InitiateForScope(tenant.Id, tenant.Name, connectionBuilder);
        }
    }
}
