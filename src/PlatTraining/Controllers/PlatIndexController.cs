using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PlatTraining.Options;
using PlatTraining.Services.Contracts;

namespace PlatTraining.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatIndexController : ControllerBase
    {
        private readonly IndexOptions _options;
        private readonly IPlatIndexService _platIndexService;

        public PlatIndexController(IOptions<IndexOptions> options,
            IPlatIndexService platIndexService)
        {
            _options = options.Value;
            _platIndexService = platIndexService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            var indexes = await _platIndexService.GetPlatIndixes();
            return Ok(indexes);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var index = await _platIndexService.GetPlatIndixeById(id);
            return Ok(index);
        }

        [HttpGet("opt")]
        public IActionResult GetOptions()
        {
            return Ok(_options);
        }
    }
}