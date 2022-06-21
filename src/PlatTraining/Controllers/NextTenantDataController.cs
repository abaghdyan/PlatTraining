using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlatTraining.Services.Contracts;

namespace PlatTraining.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NextTenantDataController : ControllerBase
    {
        private readonly INextTenantDataService _tenantDataService;

        public NextTenantDataController(INextTenantDataService tenantDataService)
        {
            _tenantDataService = tenantDataService;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Everyting is OK...");
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            var tenantData = await _tenantDataService.GetAllDataAsync();
            return Ok(tenantData);
        }
    }
}