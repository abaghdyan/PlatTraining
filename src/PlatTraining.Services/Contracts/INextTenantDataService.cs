
using PlatTraining.Data.TenantUnit.Entities;

namespace PlatTraining.Services.Contracts
{
    public interface INextTenantDataService
    {
        Task<List<NextTenantData>> GetAllDataAsync();
        Task<NextTenantData> GetDataByIdAsync(int id);
        string GetGuid();
    }
}
