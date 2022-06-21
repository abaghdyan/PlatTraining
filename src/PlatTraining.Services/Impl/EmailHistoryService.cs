using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.TenantUnit;
using PlatTraining.Data.TenantUnit.Entities;
using PlatTraining.Services.Contracts;

namespace PlatTraining.Services.Impl
{
    public class EmailHistoryService : IEmailHistoryService
    {
        private readonly TenantDbContext _dbContext;
        public EmailHistoryService(TenantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmailHistory> GetEmailHistoryRecordByIdAsync(int id)
        {
            return await _dbContext.EmailHistory.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<EmailHistory>> GetWholeEmailHistoryAsync()
        {
            return await _dbContext.EmailHistory.ToListAsync();
        }
    }
}
