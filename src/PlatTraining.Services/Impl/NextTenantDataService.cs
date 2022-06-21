using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.TenantUnit;
using PlatTraining.Data.TenantUnit.Entities;
using PlatTraining.Services.Contracts;

namespace PlatTraining.Services.Impl
{
    public class NextTenantDataService : INextTenantDataService
    {
        private readonly TenantDbContext _dbContext;
        private readonly string _guid;
        public NextTenantDataService(TenantDbContext dbContext)
        {
            _dbContext = dbContext;
            _guid = Guid.NewGuid().ToString();
        }

        public async Task<List<NextTenantData>> GetAllDataAsync()
        {
            return await _dbContext.NextTenantData.ToListAsync();
        }

        public async Task<NextTenantData> GetDataByIdAsync(int id)
        {
            return await _dbContext.NextTenantData.FirstOrDefaultAsync(i => i.Id == id);
        }

        public string GetGuid()
        {
            return _guid;
        }
    }
}
