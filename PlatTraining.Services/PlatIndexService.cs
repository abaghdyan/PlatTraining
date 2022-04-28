using Microsoft.EntityFrameworkCore;
using PlatTraining.Dal;
using PlatTraining.Dal.Entities;

namespace PlatTraining.Services.Contracts
{
    public class PlatIndexService : IPlatIndexService
    {
        private readonly PlatDbContext _dbContext;
        private readonly string _guid;
        public PlatIndexService(PlatDbContext dbContext)
        {
            _dbContext = dbContext;
            _guid = Guid.NewGuid().ToString();
        }

        public async Task<List<PlatIndex>> GetPlatIndixes()
        {
            return await _dbContext.Indexes.ToListAsync();
        }

        public async Task<PlatIndex> GetPlatIndixeById(int id)
        {
            return await _dbContext.Indexes.FirstOrDefaultAsync(i => i.Id == id);
        }

        public string GetGuid()
        {
            return _guid;
        }
    }
}
