namespace IBGEExplorer.Shared;

public static class Configuration
{
    public static DiscordConfiguration Discord { get; set; } = new();

    public class DiscordConfiguration
    {
        public string LogUrl { get; set; } = string.Empty;
    }
}