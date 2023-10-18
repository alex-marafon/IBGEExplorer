using IBGEExplorer.Shared.ValueObjects.Exceptions;

namespace IBGEExplorer.Shared.ValueObjects;

public class Name
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Name(string firstName, string lastName)
    {
        InvalidNameException.ThrowIfIsInvalid(firstName, lastName);

        FirstName = firstName;
        LastName = lastName;
    }

    public static implicit operator string(Name name)
        => $"{name.FirstName} {name.LastName}";
}