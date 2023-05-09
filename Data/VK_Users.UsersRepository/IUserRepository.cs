
namespace VK_Users.UsersRepository;

public interface IUserRepository
{
    public Task<IEnumerable<UserDetailsModel>> GetAllUsersDetails(int page, int pageSize);
    public Task<UserDetailsModel> GetUserDetails(Guid uid);
    public Task<UserModel> GetUserByUid(Guid uid);
    public Task<UserModel> GetUserByLogin(string login);
    public Task<UserDetailsModel> AddUser(AddUserModel model);
    public Task UpdateUser(UserModel userModel);
}