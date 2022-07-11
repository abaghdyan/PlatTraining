using PlatTraining.Reporting.Entities;

namespace PlatTraining.Reporting.Services
{
    public interface IReportService
    {
        Task CreateAsync(Report newReport);
        Task<List<Report>> GetAsync();
        Task<Report?> GetAsync(string id);
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, Report updatedReport);
    }
}