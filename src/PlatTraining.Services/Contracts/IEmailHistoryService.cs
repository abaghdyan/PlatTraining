using PlatTraining.Data.TenantUnit.Entities;

namespace PlatTraining.Services.Contracts
{
    public interface IEmailHistoryService
    {
        Task<List<EmailHistory>> GetWholeEmailHistoryAsync();
        Task<EmailHistory> GetEmailHistoryRecordByIdAsync(int id);
    }
}
