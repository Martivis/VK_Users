using AutoMapper;
using Moq;
using VK_Users.CacheService;
using VK_Users.Context.Entities;
using VK_Users.UserService;
using VK_Users.UsersRepository;

namespace UserServiceTest;

public class DeleteUserTest
{
    private IMapper _mapperStub;
    private IWorker _workerStub;
    private ICacheService _cacheStub;
    public DeleteUserTest()
    {
        _mapperStub = new Mock<IMapper>().Object;
        _workerStub = new Mock<IWorker>().Object;
        _cacheStub = new Mock<ICacheService>().Object;
    }

    [Fact]
    public async Task CallsUpdate()
    {
        // arrange 
        var uid = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var userModel = new UserModel()
        {
            Uid = uid,
            Login = "login",
            PasswordHash = "hash",
            CreatedDate = DateOnly.Parse("11.11.1111"),
            UserGroupId = UserGroupId.User,
            UserStateId = UserStateId.Active
        };
        var repositoryMock = new Mock<IUserRepository>();

        repositoryMock.Setup(m => m.GetUserByUid(It.Is<Guid>(v => v == uid))).ReturnsAsync(userModel);

        var userService = new UserService(repositoryMock.Object, _mapperStub, _cacheStub, _workerStub);

        // act
        await userService.DeleteUser(uid);

        // assert
        repositoryMock.Verify(m => m.UpdateUser(It.Is<UserModel>(v =>
            v.Uid == userModel.Uid &&
            v.Login == userModel.Login &&
            v.CreatedDate == userModel.CreatedDate &&
            v.UserGroupId == userModel.UserGroupId &&
            v.UserStateId == UserStateId.Blocked)),
            Times.Once);
    }
}
