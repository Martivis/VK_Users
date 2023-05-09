
using System.Collections.Concurrent;

namespace VK_Users.CacheService;

internal class InMemoryCacheService : ICacheService
{
    private readonly ConcurrentDictionary<string, bool> _cache;

    public InMemoryCacheService()
    {
        _cache = new ConcurrentDictionary<string, bool>();    
    }

    public async Task<bool> TryPutAsync(string key)
    {
        return await Task.Run(() => _cache.TryAdd(key, true));
    }

    public async Task TakeAsync(string key)
    {
        await Task.Run(() => _cache.TryRemove(KeyValuePair.Create(key, true)));
    }
}
