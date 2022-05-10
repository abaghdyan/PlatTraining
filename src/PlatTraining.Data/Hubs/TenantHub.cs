using Microsoft.EntityFrameworkCore;
using PlatTraining.Dal;

namespace PlatTraining.Common.Contexts
{
    public class TenantHub
    {
        private readonly PlatMasterDbContext _dbContext;

        public TenantHub(PlatMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string TenantId { get; set; }
        public string TenantName { get; set; }
        public string ConnectionString { get; set; }

        public async Task PopulateData(string tenantId)
        {
            var tenant = await _dbContext.Tenants.FirstAsync(t => t.Id == tenantId);
            TenantId = tenant.Id;
            TenantName = tenant.Name;
            ConnectionString = tenant.ConnectionString;
        }
    }
}
