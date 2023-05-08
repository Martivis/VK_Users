
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VK_Users.Context.Entities;

namespace VK_Users.UsersRepository;

public static class Bootstraper
{
    public static IServiceCollection AddUserRepository(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
        return services;
    }
}
