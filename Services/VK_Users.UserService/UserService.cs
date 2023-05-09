
using AutoMapper;
using VK_Users.CacheService;
using VK_Users.Context.Entities;
using VK_Users.UsersRepository;

namespace VK_Users.UserService;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cache;
    public UserService(IUserRepository userRepository, IMapper mapper, ICacheService cache)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<UserDetailsModel> AddUser(AddUserRequest model)
    {
        var addUserModel = _mapper.Map<AddUserModel>(model);
        addUserModel.UserStateId = UserStateId.Active;
        addUserModel.CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow);

        if (!await _cache.TryPutAsync(model.Login))
        {
            throw new ApplicationException($"User with login {model.Login} already exists ::pending::");
        }
        await Task.Delay(5000); // Simulation of external service work
        
        try
        {
            var user = await _userRepository.AddUser(addUserModel);
            return _mapper.Map<UserDetailsModel>(user);
        }
        finally
        {
            await _cache.TakeAsync(model.Login);
        }
    }

    public async Task DeleteUser(Guid uid)
    {
        var user = await _userRepository.GetUserByUid(uid);
        user.UserStateId = UserStateId.Blocked;

        await _userRepository.UpdateUser(user);
    }

    public async Task<IEnumerable<UserDetailsModel>> GetAllUsers(PaginationModel pagination)
    {
        return await _userRepository.GetAllUsersDetails(pagination.Page, pagination.PageSize);
    }

    public async Task<UserDetailsModel> GetUser(Guid uid)
    {
        return await _userRepository.GetUserDetails(uid);
    }
}
