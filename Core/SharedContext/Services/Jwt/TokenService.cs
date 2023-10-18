using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SharedContext.Services.Jwt;
public static class TokenService
{
        public static string GenerateToken( string userId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(ReturnClain(userId)),
            Expires = DateTime.UtcNow.AddHours(6),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.secret)),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private static IEnumerable<Claim> ReturnClain( string Id)
    {
        var userClaim = (new[]
        {
            new Claim(ClaimTypes.Name, Id.ToString()),
        }).ToList();
        return userClaim;
    }


}
