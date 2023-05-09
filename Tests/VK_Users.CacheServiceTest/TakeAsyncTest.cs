
using System.Collections.Concurrent;
using VK_Users.CacheService;

namespace InMemoryCacheServiceTest;

public class TakeAsyncTest
{
    [Fact]
    public async Task TakeExistingElement_EmptyList()
    {
        // arrange
        var cache = new InMemoryCacheService();

        var value = "value";
        var preset = new ConcurrentDictionary<string, bool>(
            new List<KeyValuePair<string, bool>>
            {
                new KeyValuePair<string, bool>(value, true),
            });

        FieldAccessor.SetValue(cache, "_cache", preset);

        var expected = new ConcurrentDictionary<string, bool>();

        // act
        await cache.TakeAsync(value);

        // assert
        var actual = FieldAccessor.GetValue<InMemoryCacheService, ConcurrentDictionary<string, bool>>(cache, "_cache");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task TakeExistingElement_RemainingElements()
    {
        // arrange
        var cache = new InMemoryCacheService();

        var value = "value";
        var presetValue = "preset";
        var preset = new ConcurrentDictionary<string, bool>(
            new List<KeyValuePair<string, bool>>
            {
                new KeyValuePair<string, bool>(presetValue, true),
                new KeyValuePair<string, bool>(value, true),
            });

        FieldAccessor.SetValue(cache, "_cache", preset);

        var expected = new ConcurrentDictionary<string, bool>(new List<KeyValuePair<string, bool>>
            {
                new KeyValuePair<string, bool>(presetValue, true),
            });

        // act
        await cache.TakeAsync(value);

        // assert
        var actual = FieldAccessor.GetValue<InMemoryCacheService, ConcurrentDictionary<string, bool>>(cache, "_cache");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task TakeNotExistingElement_NothingHappens()
    {
        // arrange
        var cache = new InMemoryCacheService();

        var presetValue = "preset";
        var preset = new ConcurrentDictionary<string, bool>(
            new List<KeyValuePair<string, bool>>
            {
                new KeyValuePair<string, bool>(presetValue, true),
            });

        FieldAccessor.SetValue(cache, "_cache", preset);

        var value = "value";
        var expected = new ConcurrentDictionary<string, bool>(
            new List<KeyValuePair<string, bool>>
            {
                new KeyValuePair<string, bool>(presetValue, true),
            });

        // act
        await cache.TakeAsync(value);

        // assert
        var actual = FieldAccessor.GetValue<InMemoryCacheService, ConcurrentDictionary<string, bool>>(cache, "_cache");

        Assert.Equal(expected, actual);
    }
}
