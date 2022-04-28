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
        private readonly IConfiguration _configuration;
        private readonly IPlatIndexService _platIndexService;
        private readonly ITransientService _transientService;

        public PlatIndexController(IConfiguration configuration,
            IOptions<IndexOptions> options,
            IPlatIndexService platIndexService,
            ITransientService transientService)
        {
            _options = options.Value;
            _configuration = configuration;
            _platIndexService = platIndexService;
            _transientService = transientService;
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

        [HttpGet("guid")]
        public IActionResult GetGuid()
        {
            var guid1 = _platIndexService.GetGuid();
            var guid2 = _transientService.GetGuidTransient();
            return Ok($"{guid1} : {guid2}");
        }
    }
}