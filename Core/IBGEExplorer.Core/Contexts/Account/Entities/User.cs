using IBGEExplorer.Core.Contexts.Shared.Entities;
using IBGEExplorer.Core.Contexts.Shared.ValueObjects;

namespace IBGEExplorer.Core.Contexts.Account.Entities;

public class User : Entity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Boolean CanLogin { get; set; }
    public Name? FullName { get; set; }

    public void ChangeUserName(Name name)
    {
        FullName = name;
    }
}