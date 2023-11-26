using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _4Create.Issuer
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        private readonly string _secretKey;
        private readonly string _issuer;

        public TokenService(IConfiguration config)
        {
            _config = config;
            _secretKey = _config.GetValue<string>("Token:secret");
            _issuer = _config.GetValue<string>("Token:issuer");
        }

        public string GenerateToken(string username, int expirationMinutes = 60)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
