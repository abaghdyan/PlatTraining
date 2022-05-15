using Microsoft.EntityFrameworkCore;
using PlatTraining.Services.Contracts;
using PlatTraining.Data.TenantUnit.Entities;
using PlatTraining.Data.TenantUnit;

namespace PlatTraining.Services.Impl
{
    public class SomeTenantDataService : ISomeTenantDataService
    {
        private readonly TenantDbContext _dbContext;
        private readonly string _guid;
        public SomeTenantDataService(TenantDbContext dbContext)
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
