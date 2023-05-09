
using VK_Users.Context.Entities;

namespace VK_Users.UsersRepository;

public class UserModel
{
    public Guid Uid { get; init; }
    public string Login { get; init; }
    public string PasswordHash { get; set; }
    public DateOnly CreatedDate { get; init; }
    public UserGroupId UserGroupId { get; set; }
    public UserStateId UserStateId { get; set; }
}
