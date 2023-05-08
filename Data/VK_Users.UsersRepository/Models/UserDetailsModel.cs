
using VK_Users.Context.Entities;

namespace VK_Users.UsersRepository;

public class UserDetailsModel
{
    public Guid Uid { get; init; }
    public string Login { get; init; }
    public DateOnly CreatedDate { get; init; }
    public UserGroupId UserGroup { get; init; }
    public string UserGroupDescription { get; init; }
    public UserStateId UserState { get; init; }
    public string UserStateDescription { get; init; }
}
