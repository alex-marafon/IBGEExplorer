using IBGEExplorer.Shared.Entities;
using IBGEExplorer.Shared.ValueObjects;

namespace IBGEExplorer.Account.Entities;

public class User : Entity<int>
{
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Boolean CanLogin { get; set; }
    public string FullName { get; set; } = null!;
    public List<UserRole>? UserRoles { get; set; }

    public void ChangeUserName(Name name)
        => FullName = name;
}