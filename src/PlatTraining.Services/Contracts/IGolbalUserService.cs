using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Services.Contracts
{
    public interface IGolbalUserService
    {
        Task<List<GlobalUser>> GetAllGlobalUsersAsync();
        Task<GlobalUser> GetGlobalUserByIdAsync(int id);
    }
}
