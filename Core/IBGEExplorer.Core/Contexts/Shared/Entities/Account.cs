namespace IBGEExplorer.Core.Contexts.Shared.Entities;

public class Account : Entity<int>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Boolean CanLogin { get; set; }
}