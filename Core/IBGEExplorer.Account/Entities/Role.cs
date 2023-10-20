using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Account.Entities;

public class Role : Entity<int>
{
    public string? Name { get; set; }
    public int RoleId { get; set; }

    public List<UserRole>? UserRoles { get; set; }
}