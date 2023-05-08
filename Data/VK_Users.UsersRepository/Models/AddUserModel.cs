
using VK_Users.Context.Entities;

namespace VK_Users.UsersRepository;

public class AddUserModel
{
    public string Login { get; init; }
    public string Password { get; set; }
    public DateOnly CreatedDate { get; set; }
    public UserGroupCode UserGroupCode { get; set; }
    public UserStateCode UserStateCode { get; set; }

}
