using Microsoft.AspNetCore.Authorization;
using PlatTraining.Data.Constants;
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
            var token = authHeader.Replace("Bearer ", string.Empty).Replace("bearer ", string.Empty);

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var tenantClaim = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == ApplicationClaims.TenantId);

            if (tenantClaim == null)
            {
                throw new ArgumentNullException($"Tenant was not found during.");
            }

            await tenantResolver.InitiateTenantInfo(tenantClaim.Value);

            await _next(context);
        }
    }
}
