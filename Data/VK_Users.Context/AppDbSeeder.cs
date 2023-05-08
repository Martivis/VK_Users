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
        if (context.Set<UserState>().Any())
            return;

        var states = new List<UserState>
        {
            new UserState
            {
                Id = UserStateId.Active,
                Code = "Active",
                Description = "Active application user",
            },
            new UserState
            {
                Id = UserStateId.Blocked,
                Code = "Blocked",
                Description = "Banned or deleted user",
            },
        };

        context.AddRange(states);
    }

    private static void AddGroups(AppDbContext context)
    {
        if (context.Set<UserGroup>().Any())
            return;

        var groups = new List<UserGroup>
        {
            new UserGroup
            {
                Id = UserGroupId.User,
                Code = "User",
                Description = "Common user",
            },
            new UserGroup
            {
                Id = UserGroupId.Admin,
                Code = "Admin",
                Description = "Application administrator",
            },
        };

        context.AddRange(groups);
    }
}
