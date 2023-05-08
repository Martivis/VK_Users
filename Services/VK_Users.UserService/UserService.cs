
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VK_Users.Context;
using VK_Users.Context.Entities;

namespace VK_Users.UserService;

internal class UserService : IUserService
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;
    public UserService(IDbContextFactory<AppDbContext> contextFactory, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    public async Task<UserDetailsModel> AddUser(AddUserModel model)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        if (await context.Set<User>().FirstAsync(e => e.Login == model.Login) is not null)
        {
            throw new ApplicationException($"User with login {model.Login} already exists");
        }

        var group = await context.Set<UserGroup>().FirstAsync(e => e.Code == model.UserGroupCode);
        var state = await context.Set<UserState>().FirstAsync(e => e.Code == UserStateCode.Active);

        var user = new User
        {
            Login = model.Login,
            CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
            UserGroup = group,
            UserState = state,
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

        await context.AddAsync(user);

        return _mapper.Map<UserDetailsModel>(user);
    }

    public async Task DeleteUser(Guid uid)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var user = await FindUser(context, uid);

        var blockedState = await context.Set<UserState>().FirstAsync(e => e.Code == UserStateCode.Blocked);
        user.UserState = blockedState;

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserDetailsModel>> GetAllUsers(int page = 0, int pageSize = 10)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var users = await context.Set<User>().Skip(page * pageSize).Take(pageSize).ToListAsync();

        return _mapper.Map<IEnumerable<UserDetailsModel>>(users);
    }

    public async Task<UserDetailsModel> GetUser(Guid uid)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var user = await FindUser(context, uid);

        return _mapper.Map<UserDetailsModel>(user);
    }

    private async Task<User> FindUser(AppDbContext context, Guid uid)
    {
        return await context.Set<User>().FindAsync(uid)
            ?? throw new ApplicationException($"User with uid {uid} not found");
    }
}
