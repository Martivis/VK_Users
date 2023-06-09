using System.Collections.Concurrent;
using VK_Users.CacheService;

namespace InMemoryCacheServiceTest;

public class TryPutAsyncTest
{
    [Fact]
    public async Task NoElement_ReturnsTrue()
    {
        // arrange
        var cache = new InMemoryCacheService();

        var value = "value";
        var expected = true;

        // act
        var actual = await cache.TryPutAsync(value);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task NoElement_ElementAdded()
    {
        // arrange
        var cache = new InMemoryCacheService();

        var value = "value";
        var expected = new ConcurrentDictionary<string, bool>(
            new List<KeyValuePair<string, bool>>
            {
                new KeyValuePair<string, bool>(value, true),
            });

        // act
        await cache.TryPutAsync(value);

        // assert
        var actual = FieldAccessor.GetValue<InMemoryCacheService, ConcurrentDictionary<string, bool>>(cache, "_cache");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task ExistingElement_ReturnsFalse()
    {
        // arrange
        var cache = new InMemoryCacheService();

        var value = "value";
        var expected = false;

        // act
        await cache.TryPutAsync(value);
        var actual = await cache.TryPutAsync(value);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task AddTwice_AddedOneElement()
    {
        // arrange
        var cache = new InMemoryCacheService();

        var value = "value";
        var expected = new ConcurrentDictionary<string, bool>(
            new List<KeyValuePair<string, bool>>
            {
                new KeyValuePair<string, bool>(value, true),
            });

        // act
        await cache.TryPutAsync(value);
        await cache.TryPutAsync(value);

        // assert
        var actual = FieldAccessor.GetValue<InMemoryCacheService, ConcurrentDictionary<string, bool>>(cache, "_cache");

        Assert.Equal(expected, actual);
    }
}