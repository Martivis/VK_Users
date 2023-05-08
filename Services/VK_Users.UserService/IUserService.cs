using VK_Users.UsersRepository;

namespace VK_Users.UserService;

public interface IUserService
{
    Task<UserDetailsModel> AddUser(AddUserRequest model);
    Task<IEnumerable<UserDetailsModel>> GetAllUsers(int page = 0, int pageSize = 10);
    Task<UserDetailsModel> GetUser(Guid uid);
    Task DeleteUser(Guid uid);
}