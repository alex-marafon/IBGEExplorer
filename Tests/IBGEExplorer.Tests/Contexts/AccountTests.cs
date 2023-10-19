using IBGEExplorer.Account.Entities;
using IBGEExplorer.Shared.Extensions;
using IBGEExplorer.Shared.ValueObjects;

namespace IBGEExplorer.Tests.Contexts;

public class AccountTests
{
    private User validUser;

    public AccountTests()
    {
        validUser = new User
        {
            Id = Guid.NewGuid(),
            Email = "joaoteste@mail.com",
            PasswordHash = StringEstensions.ToSha256("1q2w3e4r@#$"),
            // FullName = new Name("Maria", "das Dores")
            FirstName = "João", 
            LastName = "da Manga"
        };
    }

    [Fact]
    public void ShouldCreateNewAccount()
    {
        Assert.Fail("");
    }

    [Fact]
    public void ShouldNotLoginIntoTheAccountWithoutEmailConfirmation()
    {
        Assert.Fail("");
    }

    [Fact]
    public void ShouldNotLoginIntoTheDesactivatedAccount()
    {
        Assert.Fail("");
    }

    [Theory]
    [InlineData("usuario@dominio")] // Endereço sem extensão
    [InlineData("@dominio.com")] // Endereço sem nome de usuário
    [InlineData("usuario@")] // Endereço sem domínio
    [InlineData("usuario@dominio.")] // Domínio vazio
    [InlineData("usuario@dominio,com")] // Vírgula em vez de ponto
    [InlineData("usuario@dominio com")] // Espaço em vez de ponto
    [InlineData("usuário@dominio.com")] // Caractere especial "´" não permitido
    public void SouldNotCreateAccountWithInvalidEmail(string email)
    {
        Assert.Fail("");
    }

    [Theory]
    [InlineData("1234567")] // Menos de 8 caracteres
    [InlineData("12345678901234567890")] // Mais de 16 caracteres
    [InlineData("senhafraca")] // Sem símbolos especiais
    [InlineData("minha senha")] // Com espaço
    [InlineData("123456")] // Números sequenciais em ordem crescente
    [InlineData("654321")] // Números sequenciais em ordem decrescente
    [InlineData("abcdef")] // Caracteres sequenciais em ordem crescente
    [InlineData("fedcba")] // Caracteres sequenciais em ordem decrescente
    [InlineData("aaabbb")] // Mais de 2 caracteres repetidos em sequência
    public void ShouldNotCreateAccountWithInvalidPassword(string password)
    {
        Assert.Fail("");
    }

    [Fact]
    public void ShouldResetPassword()
    {
        Assert.Fail("");
    }

    //[Fact]
    //public void ShouldChangeUsername()
    //{
    //    User user = validUser;
    //   // user.ChangeUserName(new Name("Maria", "Silva"));
        
    //    Assert.NotStrictEqual(user.FullName.ToString(), validUser.FullName.ToString());
    //}
}