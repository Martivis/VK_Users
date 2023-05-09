namespace VK_Users.CacheService;

public interface ICacheService
{
    Task<bool> TryPutAsync(string key);
    Task TakeAsync(string key);
}