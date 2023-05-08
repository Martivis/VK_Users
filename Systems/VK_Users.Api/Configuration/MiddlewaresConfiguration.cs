namespace VK_Users.Api;

public static class MiddlewaresConfiguration
{
    public static void UseAppMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionsMiddleware>();
    }
}