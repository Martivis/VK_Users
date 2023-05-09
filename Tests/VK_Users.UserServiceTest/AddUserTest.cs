using AutoMapper;
using Moq;
using System.Diagnostics;
using VK_Users.CacheService;
using VK_Users.Context.Entities;
using VK_Users.UserService;
using VK_Users.UsersRepository;

namespace UserServiceTest;

public class AddUserTest
{
    private IMapper _mapperStub;
    private IWorker _workerStub;

    private AddUserRequest _addRequest;

    public AddUserTest()
    {
        _addRequest = new AddUserRequest()
        {
            Login = "login",
            Password = "password",
            UserGroupId = UserGroupId.User
        };

        var mapperStub = new Mock<IMapper>();
        mapperStub.Setup(m => m
                  .Map<AddUserModel>(It.Is<AddUserRequest>(v => v.Equals(_addRequest))))
                  .Returns(new AddUserModel()
                    {
                      Login = _addRequest.Login,
                      Password = _addRequest.Password,
                      UserGroupId = _addRequest.UserGroupId
                    });

        _mapperStub = mapperStub.Object;

        _workerStub = new Mock<IWorker>().Object;
    }

    private Mock<ICacheService> GetCacheStub(bool isCached)
    {
        var cacheStub = new Mock<ICacheService>();
        cacheStub.Setup(m => m.TryPutAsync(It.IsAny<string>()))
            .ReturnsAsync(!isCached);

        return cacheStub;
    }

    [Fact]
    public async Task NotCached_AddUserCalled()
    {
        // arrange
        var repositoryMock = new Mock<IUserRepository>();
        var cacheStub = GetCacheStub(isCached: false);

        var userService = new UserService(repositoryMock.Object, _mapperStub, cacheStub.Object, _workerStub);

        // act
        await userService.AddUser(_addRequest);

        // assert
        repositoryMock.Verify(m => m.AddUser(It.Is<AddUserModel>(v => 
            v.Login == _addRequest.Login &&
            v.Password == _addRequest.Password &&
            v.UserGroupId == _addRequest.UserGroupId &&
            v.UserStateId == UserStateId.Active &&
            v.CreatedDate == DateOnly.FromDateTime(DateTime.UtcNow))), 
            Times.Once);
    }

    [Fact]
    public async Task Cached_ThrowsApplicationException()
    {
        // arrange
        var repositoryMock = new Mock<IUserRepository>();
        var cacheStub = GetCacheStub(isCached: true);

        var userService = new UserService(repositoryMock.Object, _mapperStub, cacheStub.Object, _workerStub);

        // act-assert
        await Assert.ThrowsAsync<ApplicationException>(() => userService.AddUser(_addRequest));

    }

    [Fact]
    public async Task NotCached_DoWorkCalled()
    {
        // arrange
        var repositoryMock = new Mock<IUserRepository>();
        var cacheStub = GetCacheStub(isCached: false);

        var workerMock = new Mock<IWorker>();

        var userService = new UserService(repositoryMock.Object, _mapperStub, cacheStub.Object, workerMock.Object);

        // act
        await userService.AddUser(_addRequest);

        // assert
        workerMock.Verify(m => m.DoWork(), Times.Once);
    }

    [Fact]
    public async Task Cached_DoWorkNotCalled()
    {
        // arrange
        var repositoryMock = new Mock<IUserRepository>();
        var cacheStub = GetCacheStub(isCached: true);

        var workerMock = new Mock<IWorker>();

        var userService = new UserService(repositoryMock.Object, _mapperStub, cacheStub.Object, workerMock.Object);

        // act
        await Assert.ThrowsAsync<ApplicationException>(() => userService.AddUser(_addRequest));

        // assert
        workerMock.Verify(m => m.DoWork(), Times.Never);
    }

    [Fact]
    public async Task NotCached_PutsLogin()
    {
        // arrange
        var repositoryMock = new Mock<IUserRepository>();
        var cacheMock = GetCacheStub(isCached: false);

        var workerMock = new Mock<IWorker>();

        var userService = new UserService(repositoryMock.Object, _mapperStub, cacheMock.Object, workerMock.Object);

        // act
        await userService.AddUser(_addRequest);

        // assert
        cacheMock.Verify(m => m.TryPutAsync(It.Is<string>(v => v == _addRequest.Login)), Times.Once);
    }

    [Fact]
    public async Task NotCached_TakesLogin()
    {
        // arrange
        var repositoryMock = new Mock<IUserRepository>();
        var cacheMock = GetCacheStub(isCached: false);

        var workerMock = new Mock<IWorker>();

        var userService = new UserService(repositoryMock.Object, _mapperStub, cacheMock.Object, workerMock.Object);

        // act
        await userService.AddUser(_addRequest);

        // assert
        cacheMock.Verify(m => m.TakeAsync(It.Is<string>(v => v == _addRequest.Login)), Times.Once);
    }

    [Fact]
    public async Task Cached_DoesntTakeLogin()
    {
        // arrange
        var repositoryMock = new Mock<IUserRepository>();
        var cacheMock = GetCacheStub(isCached: true);

        var workerMock = new Mock<IWorker>();

        var userService = new UserService(repositoryMock.Object, _mapperStub, cacheMock.Object, workerMock.Object);

        // act
        await Assert.ThrowsAsync<ApplicationException>(() => userService.AddUser(_addRequest));

        // assert
        cacheMock.Verify(m => m.TakeAsync(It.Is<string>(v => v == _addRequest.Login)), Times.Never);
    }

    [Fact]
    public async Task AddUserThrowsException_TakesLogin()
    {
        // arrange
        var repositoryMock = new Mock<IUserRepository>();
        repositoryMock.Setup(m => m.AddUser(It.IsAny<AddUserModel>())).Throws<Exception>();

        var cacheMock = GetCacheStub(isCached: false);

        var workerMock = new Mock<IWorker>();

        var userService = new UserService(repositoryMock.Object, _mapperStub, cacheMock.Object, workerMock.Object);

        // act
        await Assert.ThrowsAsync<Exception>(() => userService.AddUser(_addRequest));

        // assert
        cacheMock.Verify(m => m.TakeAsync(It.Is<string>(v => v == _addRequest.Login)), Times.Once);
    }
}