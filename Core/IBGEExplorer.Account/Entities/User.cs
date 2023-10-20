using System.ComponentModel.DataAnnotations.Schema;
using IBGEExplorer.Account.UseCases.Get.Contracts;
using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Account.Entities;

public class User : Entity<int>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool CanLogin { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? HashSalt { get; private set; }
    public List<UserRole>? UserRoles { get; set; }

    public void SetHashSalt(string hashSalt) =>
        HashSalt = hashSalt;

    [NotMapped]
    public string FullName => FirstName + LastName;

    public static implicit operator Response(User user)
    {
        var roles = new List<string>();
        user.UserRoles!.ForEach(x =>
        {
            roles.Add(x.Role!.Name!);
        });

        return new Response(user.FirstName!, user.LastName!, user.Email, roles);
    }

    //public Name? FullName { get; set; }

    //public void ChangeUserName(Name name)
    //    => FullName = name;
}