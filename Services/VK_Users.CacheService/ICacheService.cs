namespace VK_Users.CacheService;

public interface ICacheService
{
    Task<bool> TryPutAsync(string value);
    Task TakeAsync(string value);
}