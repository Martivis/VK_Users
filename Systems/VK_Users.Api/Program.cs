using VK_Users.Api;
using VK_Users.CacheService;
using VK_Users.Context;
using VK_Users.UserService;
using VK_Users.UsersRepository;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAppAutoMapper();
services.AddAppDbContext();

services.AddCacheService();
services.AddUserRepository();
services.AddUserService();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

AppDbInitializer.Execute(app.Services);
AppDbSeeder.Seed(app.Services);

app.Run();
