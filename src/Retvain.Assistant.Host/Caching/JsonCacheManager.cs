using System.Text.Json;
using System.Text.RegularExpressions;
using Retvain.Assistant.Infrastructure.Ports;

namespace Retvain.Assistant.Host.Caching;

internal sealed class JsonCacheManager : ICacheManager
{
    private const string CacheFilePath = "cache.json";

    private readonly CacheData _cacheData;

    public JsonCacheManager()
    {
        if (File.Exists(CacheFilePath))
        {
            var json = File.ReadAllText(CacheFilePath);
            _cacheData = JsonSerializer.Deserialize<CacheData>(json) ?? new CacheData();
        }
        else
            _cacheData = new CacheData();
    }

    public string GetPureServersSession()
        => _cacheData.Session ?? string.Empty;

    public void SetPureServersSession(string session)
    {
        _cacheData.Session = CleanJsonString(session);
        SaveCache();
    }

    private void SaveCache()
    {
        var json = JsonSerializer.Serialize(_cacheData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(CacheFilePath, json);
    }

    private static string CleanJsonString(string jsonString)
        => Regex.Replace(jsonString, @"\s+", string.Empty);
}