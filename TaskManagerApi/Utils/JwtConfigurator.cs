using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagerApi.Models;

namespace TaskManagerApi.Utils
{
    public class JwtConfigurator
    {
        public static string GenerateJwtToken(UserApp userApp, IConfiguration config)
        {
            string SecretKey = config["Jwt:SecretKey"];
            string Issuer = config["Jwt:Issuer"];
            string Audience = config["Jwt:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userApp.UserName),
                new Claim("UserId", userApp.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static int GetTokenUserId(ClaimsIdentity identity)
        {
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                foreach (var claim in claims)
                {
                    if (claim.Type == "UserId")
                    {
                        return int.Parse(claim.Value);
                    }
                }
            }
            return 0;
        }
    }
}
