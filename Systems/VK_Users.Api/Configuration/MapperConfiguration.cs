namespace VK_Users.Api;

public static class MapperConfiguration
{
    public static IServiceCollection AddAppAutoMapper(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName is not null);
        services.AddAutoMapper(assemblies);
        return services;
    }
}
