using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK_Users.Context.Entities;

namespace VK_Users.UserService;

public static class Bootstraper
{
    public static IServiceCollection AddUserService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddSingleton<IWorker, WorkerStub>();
        return services;
    }
}
