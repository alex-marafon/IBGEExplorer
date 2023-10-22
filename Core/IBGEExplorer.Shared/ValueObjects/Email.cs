using IBGEExplorer.Shared.ValueObjects.Exceptions;

namespace IBGEExplorer.Shared.ValueObjects;

public class Email
{
    public string Address { get; set; } = null!;

    public Email(string address)
    {
        InvalidEmailException.ThrowIfIsInvalid(address);
        Address = address;
    }
}