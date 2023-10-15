using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SharedContext.Services.Jwt.Contracts;
using System.Text;

namespace SharedContext.Services.Jwt;
public class TokenService : ITokenService
{
    public string GenerateToken(string Email, string Id)
    {
        #region Erro na chamada TokenHandler

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, Id.ToString()), //User.Identity.Name
                    new Claim(ClaimTypes.Role, Email) //User.IsInRole
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.secret)),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); //Erro
            return tokenHandler.WriteToken(token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

        #endregion


    }
}
