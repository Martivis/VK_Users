namespace VK_Users.UserService;

public interface IUserService
{
    Task<UserDetailsModel> AddUser(AddUserModel model);
    Task<IEnumerable<UserDetailsModel>> GetAllUsers();
    Task<UserDetailsModel> GetUser(Guid Uid);
    Task DeleteUser(Guid Uid);
}