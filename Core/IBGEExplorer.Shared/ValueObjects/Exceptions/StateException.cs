namespace IBGEExplorer.Shared.ValueObjects.Exceptions;

public class StateException : Exception
{
    public StateException(string message = "Invalid data for state") : base(message)
    {
    }
    public static void ThrowIfIsInvalid((string Code, string Acronym, string Name) city)
    {
        if (string.IsNullOrEmpty(city.Code) || string.IsNullOrEmpty(city.Acronym) || string.IsNullOrEmpty(city.Name))
            throw new CityException("Complete all the fields correctly");

        if (city.Acronym.Length > 2)
            throw new CityException("field must have 2 or fewer characters");
    }
}