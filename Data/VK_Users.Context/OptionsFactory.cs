﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_Users.Context;

internal static class OptionsFactory
{
    public static DbContextOptions<AppDbContext> Create(string connectionString)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        Configure(connectionString).Invoke(builder);
        return builder.Options;
    }

    public static Action<DbContextOptionsBuilder> Configure(string connectionString)
    {
        return optionsBuilder =>
        {
            optionsBuilder.UseNpgsql(connectionString, options =>
            {
                options.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds)
                    .MigrationsHistoryTable(tableName: "_EFMigrationHistory", schema: "vk_users")
                    .MigrationsAssembly("VK_Users.Context.Migrations");
            })
            .EnableSensitiveDataLogging()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        };
    }
}
