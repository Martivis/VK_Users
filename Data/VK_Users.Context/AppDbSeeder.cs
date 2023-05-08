using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK_Users.Context.Entities;

namespace VK_Users.Context;

public static class AppDbSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        AddStates(context);
        AddGroups(context);

        context.SaveChanges();
    }

    private static void AddStates(AppDbContext context)
    {
        var states = new List<UserState>
        {
            new UserState
            {
                Code = UserStateCode.Active,
                Description = "Active application user",
            },
            new UserState
            {
                Code = UserStateCode.Blocked,
                Description = "Banned or deleted user",
            },
        };

        context.AddRange(states);
    }

    private static void AddGroups(AppDbContext context)
    {
        var groups = new List<UserGroup>
        {
            new UserGroup
            {
                Code = UserGroupCode.User,
                Description = "Common user",
            },
            new UserGroup
            {
                Code = UserGroupCode.Admin,
                Description = "Application administrator",
            },
        };

        context.AddRange(groups);
    }
}
