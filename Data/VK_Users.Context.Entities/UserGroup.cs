
namespace VK_Users.Context.Entities;

public class UserGroup
{
    public UserGroupId Id { get; set; }
    public string Code { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<User> Users { get; set; } = null!;
}
