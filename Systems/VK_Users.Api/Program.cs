using VK_Users.Api;
using VK_Users.AuthService;
using VK_Users.CacheService;
using VK_Users.Context;
using VK_Users.UserService;
using VK_Users.UsersRepository;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddAppSwagger();

services.AddAppAutoMapper();
services.AddAppDbContext();

services.AddCacheService();
services.AddUserRepository();
services.AddUserService();
services.AddAuthService();

services.AddAppAuth();

var app = builder.Build();

app.UseAppSwagger();

app.UseAuthorization();

app.MapControllers();

app.UseAppMiddlewares();

AppDbInitializer.Execute(app.Services);
AppDbSeeder.Seed(app.Services);

app.Run();
