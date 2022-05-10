using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.DbContexts;
using PlatTraining.Data.Entities.Tenant;
using PlatTraining.Services.Contracts;

namespace PlatTraining.Services.Impl
{
    public class SomeTenantDataService : ISomeTenantDataService
    {
        private readonly PlatTenantDbContext _dbContext;
        private readonly string _guid;
        public SomeTenantDataService(PlatTenantDbContext dbContext)
        {
            _dbContext = dbContext;
            _guid = Guid.NewGuid().ToString();
        }

        public async Task<List<SomeTenantData>> GetAllDataAsync()
        {
            return await _dbContext.SomeTenantData.ToListAsync();
        }

        public async Task<SomeTenantData> GetDataByIdAsync(int id)
        {
            return await _dbContext.SomeTenantData.FirstOrDefaultAsync(i => i.Id == id);
        }

        public string GetGuid()
        {
            return _guid;
        }
    }
}
