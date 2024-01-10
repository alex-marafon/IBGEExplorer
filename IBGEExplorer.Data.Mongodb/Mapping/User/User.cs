using IBGEExplorer.Account.Entities;

namespace IBGEExplorer.Data.Mongodb.Mapping.User;
public class User
{
    public string Email { get; set; }
    public string Password { get; set; } 
    public bool CanLogin { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string HashSalt { get; private set; }
    public List<UserRole> UserRoles { get; set; } = new List<UserRole>();


    public static User MapperUserDb(Account.Entities.User user)
    {
        var use = new Mapping.User.User
        {
            CanLogin = user.CanLogin,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Password = user.Password,
            UserRoles = user.UserRoles
        };
        return use;
    }
}