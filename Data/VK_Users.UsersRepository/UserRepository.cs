
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VK_Users.Context;
using VK_Users.Context.Entities;

namespace VK_Users.UsersRepository;

internal class UserRepository : IUserRepository, IDisposable
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserRepository(IDbContextFactory<AppDbContext> contextFactory, IMapper mapper, IPasswordHasher<User> passwordHasher)
    {
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _context = contextFactory.CreateDbContext();
    }

    public async Task<UserDetailsModel> AddUser(AddUserModel model)
    {
        if (await _context.Set<User>().AnyAsync(e => e.Login == model.Login))
        {
            throw new ApplicationException($"User with login {model.Login} already exists");
        }
        if (model.UserGroupId == UserGroupId.Admin &&
            await _context.Set<User>().AnyAsync(e => e.UserGroupId == UserGroupId.Admin))
        {
            throw new ApplicationException($"Administrator already exists");
        }

        var user = _mapper.Map<User>(model);
        user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

        await _context.AddAsync(user);
        await _context.SaveChangesAsync();

        return _mapper.Map<UserDetailsModel>(user);
    }

    public async Task<UserModel> GetUserByUid(Guid uid)
    {
        var user = await _context.Set<User>().FindAsync(uid)
            ?? throw new ApplicationException($"User with uid {uid} not found");

        return _mapper.Map<UserModel>(user);
    }

    public async Task<IEnumerable<UserDetailsModel>> GetAllUsersDetails(int page, int pageSize)
    {
        var users = await _context.Set<User>()
            .Include(e => e.UserGroup)
            .Include(e => e.UserState)
            .Skip(page * pageSize).Take(pageSize)
            .ToListAsync();

        return _mapper.Map<IEnumerable<UserDetailsModel>>(users);
    }

    public async Task<UserDetailsModel> GetUserDetails(Guid uid)
    {
        var users = await _context.Set<User>()
            .Include(e => e.UserGroup)
            .Include(e => e.UserState)
            .FirstAsync(e => e.Uid == uid);

        return _mapper.Map<UserDetailsModel>(users);
    }

    public async Task UpdateUser(UserModel userModel)
    {
        var user = _mapper.Map<User>(userModel);

        _context.Update(user);
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
