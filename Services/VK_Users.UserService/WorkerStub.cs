
namespace VK_Users.UserService;

internal class WorkerStub : IWorker
{
    public async Task DoWork()
    {
        await Task.Delay(5000);
    }
}
