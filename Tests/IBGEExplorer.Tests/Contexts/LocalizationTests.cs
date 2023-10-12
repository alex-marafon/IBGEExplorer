namespace IBGEExplorer.Tests.Contexts;

public class LocalizationTests
{
    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData("!@#$%^&*")]
    [InlineData("12345")]
    [InlineData("Cidade@Nome")]
    [InlineData("🏙️")]
    [InlineData("<script>alert('Ataque XSS')</script>")]
    [InlineData("Cidade\nNome")]
    [InlineData("C!tyN@me")]
    public void ShouldNotAcceptInvalidCitySearchString(string searchString)
    {
        Assert.Fail("");
    }

    [Fact]
    public void ShouldNotAcceptInvalidStateSearchString()
    {
        Assert.Fail("");
    }

    [Fact]
    public void ShouldNotAcceptInvalidIBGECode()
    {
        Assert.Fail("");
    }

    [Fact]
    public void ShouldAcceptMultiplesStatesSearchString()
    {
        Assert.Fail("");
    }

    [Fact]
    public void ShouldAcceptMultiplesCitiesSearchString()
    {
        Assert.Fail("");
    }

    [Fact]
    public void ShouldAcceptMultiplesIBGECodesSearchString()
    {
        Assert.Fail("");
    }
}