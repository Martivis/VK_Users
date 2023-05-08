
namespace VK_Users.Context.Entities;

public class UserState
{
    public int Id { get; set; }
    public UserStateCode Code { get; set; }
    public string Description { get; set; } = null!;
    public ICollection<User> Users { get; set; } = null!;
}
