using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Account.Entities;

public class Role : Entity<short>
{
    public string? Name { get; set; }

    public List<UserRole>? UserRoles { get; set; }
}