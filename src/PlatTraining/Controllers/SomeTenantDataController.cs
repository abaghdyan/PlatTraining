using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlatTraining.Services.Contracts;

namespace PlatTraining.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SomeTenantDataController : ControllerBase
    {
        private readonly ISomeTenantDataService _tenantDataService;

        public SomeTenantDataController()
        {
        }

        //public PlatIndexController(IPlatIndexService tenantDataService)
        //{
        //    _tenantDataService = tenantDataService;
        //}

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            return Ok("OOOOOOkkkkkk");
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            var tenantData = await _tenantDataService.GetAllDataAsync();
            return Ok(tenantData);
        }
    }
}