
namespace VK_Users.Context.Entities;

public class User : EntityBase
{
    public string Login { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateOnly CreatedDate { get; set; }
    public Guid UserGroupUid { get; set; }
    public virtual UserGroup UserGroup { get; set; } = null!;
    public Guid UserStateUid { get; set; }
    public virtual UserState UserState { get; set; } = null!;
}
