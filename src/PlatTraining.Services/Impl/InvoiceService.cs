using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.TenantUnit;
using PlatTraining.Data.TenantUnit.Entities;
using PlatTraining.Services.Contracts;

namespace PlatTraining.Services.Impl
{
    public class InvoiceService : IInvoiceService
    {
        private readonly TenantDbContext _dbContext;
        public InvoiceService(TenantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await _dbContext.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _dbContext.Invoices.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
