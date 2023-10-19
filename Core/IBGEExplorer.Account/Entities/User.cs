using System.ComponentModel.DataAnnotations.Schema;
using IBGEExplorer.Shared.Entities;
using IBGEExplorer.Shared.ValueObjects;

namespace IBGEExplorer.Account.Entities;

public class User : Entity
{
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public bool CanLogin { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string HashSalt { get; set; }
    
    [NotMapped]
    public string FullName => FirstName + LastName;

    //public Name? FullName { get; set; }
    
    //public void ChangeUserName(Name name)
    //    => FullName = name;
}