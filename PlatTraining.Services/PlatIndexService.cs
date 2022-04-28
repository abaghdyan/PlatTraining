using Microsoft.EntityFrameworkCore;
using PlatTraining.Dal;
using PlatTraining.Dal.Entities;

namespace PlatTraining.Services.Contracts
{
    public class PlatIndexService : IPlatIndexService
    {
        private readonly PlatDbContext _dbContext;
        public PlatIndexService(PlatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PlatIndex>> GetPlatIndixes()
        {
            return await _dbContext.Indexes.ToListAsync();
        }

        public async Task<PlatIndex> GetPlatIndixeById(int id)
        {
            return await _dbContext.Indexes.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
