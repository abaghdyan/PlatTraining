using Microsoft.AspNetCore.Mvc;
using PlatTraining.Data.Models;
using PlatTraining.Services.Contracts;

namespace PlatTraining.Controllers
{
    [Route("[controller]")]
    public class InvoiceController : TenantControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(TenantInfo tenantInfo, IInvoiceService invoiceService)
            : base(tenantInfo)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetAllAsync(int recordId)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(recordId);
            return Ok(invoice);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }
    }
}