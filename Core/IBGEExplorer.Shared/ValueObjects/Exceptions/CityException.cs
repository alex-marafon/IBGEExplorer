namespace IBGEExplorer.Shared.ValueObjects.Exceptions;

public class CityException : Exception
{
    public CityException(string message = "Invalid data for IBGE") : base(message)
    {
    }
    public static void ThrowIfIsInvalid((string IBGECode, string CountyCode, string StateCode) data)
    {
        if (string.IsNullOrEmpty(data.IBGECode) || string.IsNullOrEmpty(data.CountyCode) || string.IsNullOrEmpty(data.StateCode) )
            throw new CityException("Complete all the fields correctly");
    }
}