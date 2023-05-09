
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VK_Users.UserService;
using VK_Users.UsersRepository;

namespace VK_Users.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<UserDetailsModel>> GetAll(int page = 0, int pageSize = 10)
    {
        return await _userService.GetAllUsers(page, pageSize);
    }

    [Authorize]
    [HttpGet("{uid}")]
    public async Task<UserDetailsModel> Get(Guid uid)
    {
        return await _userService.GetUser(uid);
    }

    [HttpPost]
    public async Task<UserDetailsModel> Add([FromBody] AddUserRequest model)
    {
        return await _userService.AddUser(model);
    }

    [HttpPut("{uid}")]
    public async Task Delete(Guid uid)
    {
        await _userService.DeleteUser(uid);
    }
}
