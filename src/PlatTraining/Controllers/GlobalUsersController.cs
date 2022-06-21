using Microsoft.AspNetCore.Mvc;
using PlatTraining.Services.Contracts;

namespace PlatTraining.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlobalUsersController : MasterControllerBase
    {
        private readonly IGolbalUserService _golbalUserService;

        public GlobalUsersController(IGolbalUserService golbalUserService)
        {
            _golbalUserService = golbalUserService;
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetAllAsync(int userId)
        {
            var invoices = await _golbalUserService.GetGlobalUserByIdAsync(userId);
            return Ok(invoices);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetByIdAsync()
        {
            var invoice = await _golbalUserService.GetAllGlobalUsersAsync();
            return Ok(invoice);
        }
    }
}