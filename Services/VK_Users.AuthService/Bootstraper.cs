using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK_Users.Context.Entities;
using VK_Users.UsersRepository;

namespace VK_Users.AuthService;

public static class Bootstraper
{
    public static IServiceCollection AddAuthService(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddSingleton<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();
        return services;
    }
}
