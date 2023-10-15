namespace SharedContext.Services.Jwt.Contracts;
public interface ITokenService
{
    string GenerateToken(string Email, string Id);
}
