using System.Security.Claims;

namespace VK_Users.AuthService;

public interface IAuthService
{
    public Task<ClaimsIdentity?> AuthenticateAsync(string username, string password);
}