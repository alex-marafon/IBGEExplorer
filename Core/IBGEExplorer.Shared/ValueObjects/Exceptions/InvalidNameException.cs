namespace IBGEExplorer.Shared.ValueObjects.Exceptions;

public class InvalidNameException : Exception
{
    public InvalidNameException( ) : base("Invalid username")
    {
    }

    public static void ThrowIfIsInvalid(string? firstName, string? lastName)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new InvalidNameException();

        if (string.IsNullOrEmpty(lastName))
            throw new InvalidNameException();

        firstName = firstName.Trim();
        lastName = lastName.Trim();

        if (firstName.Length < 3 || lastName.Length < 3)
            throw new InvalidNameException();
    }
}