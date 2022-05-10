using PlatTraining.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;

namespace Plat.Analytics.Common.AspNet.Middlewares
{
    public class TenantResolutionMiddlware
    {
        private readonly RequestDelegate _next;

        public TenantResolutionMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITokenService tokenService)
        {
            if (context == null)
            {
                return;
            }

            string authHeader = context.Request?.Headers["Authorization"];
            var token = authHeader.Replace("Bearer ", "").Replace("bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var id = jwtSecurityToken.Claims.First(c => c.Value == "TenantId").Value;

            await _next(context);
        }
    }
}
