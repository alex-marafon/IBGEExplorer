namespace IBGEExplorer.Shared.ValueObjects.Exceptions;

public class InvalidEmailException : Exception
{
    public InvalidEmailException(string message = "Invalid email address") : base(message)
    {
    }

    public static void ThrowIfIsInvalid(string? address)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidEmailException("Email must be declared");

        address = address.Trim();

        if (address.Length < 5)
            throw new InvalidEmailException("The length of the email address must be between 5 and 16 characters");
    }
}