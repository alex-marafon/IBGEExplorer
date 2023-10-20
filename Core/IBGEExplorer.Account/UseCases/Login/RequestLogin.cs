namespace IBGEExplorer.Account.UseCases.Login;

public class RequestLogin
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}