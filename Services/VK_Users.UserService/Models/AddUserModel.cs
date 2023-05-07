
using VK_Users.Context.Entities;

namespace VK_Users.UserService;

public class AddUserModel
{
    public string Login { get; init; }
    public string Password { get; init; }
    public UserGroupCode UserGroupCode { get; init; }
}
