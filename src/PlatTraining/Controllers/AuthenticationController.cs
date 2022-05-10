using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlatTraining.Services.Contracts;

namespace PlatTraining.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpGet("signin")]
        public async Task<IActionResult> Test(string userName, string tenantId)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(tenantId))
            {
                return BadRequest("userName or tenantId is empty.");
            }
            var token = _tokenService.GenerateAccessToken(userName, tenantId);
            return Ok(token);
        }

    }
}