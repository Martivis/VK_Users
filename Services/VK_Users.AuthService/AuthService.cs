
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using VK_Users.UsersRepository;

namespace VK_Users.AuthService;

internal class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<UserModel> _passwordHasher;

    public AuthService(IUserRepository userRepository, IPasswordHasher<UserModel> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ClaimsIdentity?> AuthenticateAsync(string username, string password)
    {
        UserModel user;
        try
        {
            user = await _userRepository.GetUserByLogin(username);
        }
        catch (ApplicationException) 
        {
            return null;
        }

        if (!CheckPassword(user, password))
            return null;

        var identity = new ClaimsIdentity(
            claims: new[]
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.NameIdentifier, user.Uid.ToString()),
                new Claim(ClaimTypes.Role, user.UserGroupId.ToString()),
            }, 
            authenticationType: "Basic");

        return identity;
    }

    public bool CheckPassword(UserModel user, string password)
    {
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        if (result == PasswordVerificationResult.Success)
            return true;
        return false;
    }
}
