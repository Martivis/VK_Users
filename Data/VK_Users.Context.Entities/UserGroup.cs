
namespace VK_Users.Context.Entities;

public class UserGroup : EntityBase
{
    public UserGroupCode Code { get; set; }
    public string Description { get; set; } = null!;
    public ICollection<User> Users { get; set; } = null!;
}
