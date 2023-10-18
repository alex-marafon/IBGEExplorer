namespace IBGEExplorer.Shared.ValueObjects;

public record Error
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    
    public Error(string value, string key = "")
    {
        Key = string.IsNullOrEmpty(key)
            ? Guid.NewGuid().ToString().Replace("-", "")[..8]
            : key;

        Value = value;
    }
}