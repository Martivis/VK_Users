
namespace VK_Users.Context.Entities;

public class User
{
    public Guid Uid { get; set; }
    public string Login { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateOnly CreatedDate { get; set; }
    public UserGroupId UserGroupId { get; set; }
    public virtual UserGroup UserGroup { get; set; } = null!;
    public UserStateId UserStateId { get; set; }
    public virtual UserState UserState { get; set; } = null!;
}
