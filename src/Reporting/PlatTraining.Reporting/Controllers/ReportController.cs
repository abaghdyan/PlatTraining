using Microsoft.AspNetCore.Mvc;
using PlatTraining.Reporting.Entities;
using PlatTraining.Reporting.Services;

namespace PlatTraining.Reporting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _reportService.GetAsync();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _reportService.GetAsync(id);
            return Ok(response);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Report report)
        {
            await _reportService.CreateAsync(report);
            return Ok("Created");
        }
    }
}