namespace IBGEExplorer.Shared.ValueObjects.Exceptions;

public class CityException : Exception
{
    public CityException(string message = "Invalid data for city") : base(message)
    {
    }
    public static void ThrowIfIsInvalid((string IBGECode, string CityName, string StateName) city)
    {
        if (string.IsNullOrEmpty(city.IBGECode) || string.IsNullOrEmpty(city.CityName) || string.IsNullOrEmpty(city.StateName))
            throw new CityException("Complete all the fields correctly");
    }
}