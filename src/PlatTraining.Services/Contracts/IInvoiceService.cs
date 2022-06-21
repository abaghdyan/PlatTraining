using PlatTraining.Data.TenantUnit.Entities;

namespace PlatTraining.Services.Contracts
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetAllInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(int id);
    }
}
