
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VK_Users.Context;

public static class AppDbInitializer
{
    private const int MaxRetries = 5;
    private const int RetryDelayMs = 1000;

    public static void Execute(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();

        int retries = 0;
        while (retries < MaxRetries)
        {
            try
            {
                using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.Database.Migrate();
                return;
            }
            catch (Exception)
            {
                retries++;
                Task.Delay(RetryDelayMs).Wait();

                if (retries >= MaxRetries)
                    throw;
            }
        }
    }
}
