
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VK_Users.Context;
using VK_Users.Context.Entities;
using VK_Users.UsersRepository;

namespace VK_Users.UserService;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDetailsModel> AddUser(AddUserRequest model)
    {
        var addUserModel = _mapper.Map<AddUserModel>(model);
        addUserModel.UserStateCode = UserStateCode.Active;
        addUserModel.CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow);

        var user = await _userRepository.AddUser(addUserModel);

        return _mapper.Map<UserDetailsModel>(user);
    }

    public async Task DeleteUser(Guid uid)
    {
        var user = await _userRepository.GetUserByUid(uid);
        user.UserStateId = 1;

        await _userRepository.UpdateUser(user);
    }

    public async Task<IEnumerable<UserDetailsModel>> GetAllUsers(int page = 0, int pageSize = 10)
    {
        return await _userRepository.GetAllUsersDetails(page, pageSize);
    }

    public async Task<UserDetailsModel> GetUser(Guid uid)
    {
        return await _userRepository.GetUserDetails(uid);
    }
}
