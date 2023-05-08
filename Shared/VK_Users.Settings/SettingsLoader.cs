using Microsoft.Extensions.Configuration;

namespace VK_Users.Settings;

public static class SettingsLoader
{
    public static T Load<T>(string key) where T : new()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var settings = new T();

        configuration.GetSection(key).Bind(settings);
        return settings;
    }
}