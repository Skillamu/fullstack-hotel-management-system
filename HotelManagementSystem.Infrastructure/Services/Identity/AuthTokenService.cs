using HotelManagementSystem.Core.Application.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelManagementSystem.Infrastructure.Services.Identity
{
    public class AuthTokenService : IAuthTokenService
    {
        private readonly AuthTokenOptions _options;

        public AuthTokenService(IOptions<AuthTokenOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(Guid guestId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: new[] { new Claim("guest_id", $"{guestId}") },
                expires: DateTime.Now.AddSeconds(180),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
