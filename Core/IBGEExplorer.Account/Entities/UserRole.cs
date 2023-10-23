using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Account.Entities;

public class UserRole : Entity<short>
{
    public int UserId { get; set; }
    public short RoleId { get; set; }
    public User? User { get; set; }
    public Role? Role { get; set; }
}