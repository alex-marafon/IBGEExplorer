using IBGEExplorer.Shared.Entities;
using IBGEExplorer.Shared.ValueObjects;

namespace IBGEExplorer.Account.Entities;

public class User : Entity
{
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Boolean CanLogin { get; set; }
    public Name? FullName { get; set; }

    public void ChangeUserName(Name name)
        => FullName = name;
}