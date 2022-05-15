using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlatTraining.Data.Constants;
using PlatTraining.Services.Contracts;
using PlatTraining.Services.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PlatTraining.Services.Impl
{
    public class TokenService : ITokenService
    {
        private readonly JwtTokenOptions _tokenOptions;
        public TokenService(IOptions<JwtTokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }

        public string GenerateAccessToken(string userName, string tenantId)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ApplicationClaims.TenantId, tenantId),
            };

            var key = new SymmetricSecurityKey(_tokenOptions.Secret);
            var expirationTime = DateTime.UtcNow.AddMonths(_tokenOptions.AccessTokenDurationInMinutesRememberMe);
            var jwtToken = new JwtSecurityToken(issuer: "Blinkingcaret",
                                                audience: "Anyone",
                                                claims: claims,
                                                notBefore: DateTime.UtcNow,
                                                expires: expirationTime,
                                                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                                                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
