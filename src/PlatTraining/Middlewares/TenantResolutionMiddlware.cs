using Microsoft.AspNetCore.Authorization;
using PlatTraining.Data.Services;
using System.IdentityModel.Tokens.Jwt;

namespace PlatTraining.Middlewares
{
    public class TenantResolutionMiddlware
    {
        private readonly RequestDelegate _next;

        public TenantResolutionMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITenantResolver tenantResolver)
        {
            if (context == null)
            {
                return;
            }

            var endpoint = context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                await _next(context);
                return;
            }

            string authHeader = context.Request?.Headers["Authorization"];
            var token = authHeader.Replace("Bearer ", "").Replace("bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var tenantId = jwtSecurityToken.Claims.First(c => c.Type.ToLower() == "tenantid").Value;

            await tenantResolver.InitiateTenantHub(tenantId);

            await _next(context);
        }
    }
}
