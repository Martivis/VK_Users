using VK_Users.UsersRepository;

namespace VK_Users.UserService;

public interface IUserService
{
    Task<UserDetailsModel> AddUser(AddUserRequest model);
    Task<IEnumerable<UserDetailsModel>> GetAllUsers(PaginationModel pagination);
    Task<UserDetailsModel> GetUser(Guid uid);
    Task DeleteUser(Guid uid);
}