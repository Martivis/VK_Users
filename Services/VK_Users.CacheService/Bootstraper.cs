using Microsoft.Extensions.DependencyInjection;

namespace VK_Users.CacheService;

public static class Bootstraper
{
    public static IServiceCollection AddCacheService(this IServiceCollection services)
    {
        services.AddSingleton<ICacheService, InMemoryCacheService>();
        return services;
    }
}
