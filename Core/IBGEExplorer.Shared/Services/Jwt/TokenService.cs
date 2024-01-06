using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace IBGEExplorer.Shared.Services.Jwt;

public static class TokenService
{
    #region GenerateToken Default
    public static string GenerateToken(string userId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new List<Claim>
            {
                new Claim("UserId", userId)
            }),
            Expires = DateTime.UtcNow.AddHours(6),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.secret)),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    #endregion


    #region GenerateToken personal

    //public static string GenerateToken(string userId)
    //{
    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var tokenDescriptor = new SecurityTokenDescriptor
    //    {
    //        Subject = new ClaimsIdentity(ReturnClain(userId)),
    //        Expires = DateTime.UtcNow.AddHours(6),
    //        SigningCredentials = new SigningCredentials(
    //            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.secret)),
    //            SecurityAlgorithms.HmacSha256Signature)
    //    };

    //    var token = tokenHandler.CreateToken(tokenDescriptor);
    //    return tokenHandler.WriteToken(token);
    //}

    //private static IEnumerable<Claim> ReturnClain(string Id)
    //{
    //    var userClaim = (new[]
    //    {
    //        new Claim(ClaimTypes.Name, Id.ToString()),
    //    }).ToList();

    //    return userClaim;
    //}

    #endregion


    #region ValidareToken

    public static ClaimsPrincipal ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.secret);

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ClockSkew = TimeSpan.Zero
        };

        SecurityToken validatedToken;
        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            return principal;
        }
        catch (Exception)
        {
            return null;
        }
    }

    #endregion

}