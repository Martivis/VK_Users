
namespace VK_Users.UsersRepository;

public class UserModel
{
    public Guid Uid { get; init; }
    public string Login { get; init; }
    public string PasswordHash { get; set; }
    public DateOnly CreatedDate { get; init; }
    public int UserGroupId { get; set; }
    public int UserStateId { get; set; }
}
