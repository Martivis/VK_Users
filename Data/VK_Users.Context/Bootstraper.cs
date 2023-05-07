using Microsoft.Extensions.DependencyInjection;
using VK_Users.Settings;

namespace VK_Users.Context;

public static class Bootstraper
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services)
    {
        var setting = SettingsLoader.Load<AppDbSettings>("Database");

        services.AddDbContextFactory<AppDbContext>(OptionsFactory.Configure(setting.ConnectionString));
        return services;
    }
}
