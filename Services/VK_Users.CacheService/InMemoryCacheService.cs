
using System.Collections.Concurrent;

namespace VK_Users.CacheService;

internal class InMemoryCacheService : ICacheService
{
    private readonly ConcurrentBag<string> _cache;

    public InMemoryCacheService()
    {
        _cache = new ConcurrentBag<string>();    
    }

    public async Task<bool> TryPutAsync(string value)
    {
        return await Task.Run(() => 
        {
            if (_cache.Any(i => i == value))
            {
                return false;
            }
            _cache.Add(value);
            return true;
        });
    }

    public async Task TakeAsync(string value)
    {
        await Task.Run(() => _cache.TryTake(out value!));
    }
}
