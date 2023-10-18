using IBGEExplorer.Core.Contexts.Shared.ValueObjects.Exceptions;

namespace IBGEExplorer.Core.Contexts.Shared.ValueObjects;

public abstract class Name
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Name(string firstName, string lastName)
    {
        InvalidNameException.ThrowIfIsInvalid(firstName, lastName);

        FirstName = firstName;
        LastName = lastName;
    }

    public static implicit operator Name(string fullName)
    {
       // InvalidNameException.ThrowIfIsInvalid(fullName);

        return new Name(firstName, lastName);
    }


}