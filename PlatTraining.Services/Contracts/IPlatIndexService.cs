using PlatTraining.Dal.Entities;

namespace PlatTraining.Services.Contracts
{
    public interface IPlatIndexService
    {
        Task<List<PlatIndex>> GetPlatIndixes();
        Task<PlatIndex> GetPlatIndixeById(int id);
    }
}
