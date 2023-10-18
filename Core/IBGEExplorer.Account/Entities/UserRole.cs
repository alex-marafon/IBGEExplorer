using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Account.Entities;

public class UserRole : Entity<int>
{
    public int UserId { get; set; }
    public int RoleId { get; set; }

    public User? User { get; set; }
    public Role? Role { get; set; }
}