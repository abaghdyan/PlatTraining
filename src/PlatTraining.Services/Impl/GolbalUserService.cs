using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.MasterUnit;
using PlatTraining.Data.MasterUnit.Entities;
using PlatTraining.Services.Contracts;

namespace PlatTraining.Services.Impl
{
    public class GolbalUserService : IGolbalUserService
    {
        private readonly MasterDbContext _dbContext;
        public GolbalUserService(MasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GlobalUser>> GetAllGlobalUsersAsync()
        {
            return await _dbContext.GlobalUsers.ToListAsync();
        }

        public async Task<GlobalUser> GetGlobalUserByIdAsync(int id)
        {
            return await _dbContext.GlobalUsers.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
