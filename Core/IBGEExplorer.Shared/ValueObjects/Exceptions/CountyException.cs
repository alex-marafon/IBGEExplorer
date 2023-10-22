namespace IBGEExplorer.Shared.ValueObjects.Exceptions;

public class CountyException : Exception
{
    public CountyException(string message = "Invalid data for county") : base(message)
    {
    }
    public static void ThrowIfIsInvalid((string Code, string Name) city)
    {
        if (string.IsNullOrEmpty(city.Code) || string.IsNullOrEmpty(city.Name))
            throw new CityException("Complete all the fields correctly");
    }
}