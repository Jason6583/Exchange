using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRedisCache
    {
        RedisValue StringGet(string key);

        Task<RedisValue> StringGetAsync(string key);

        bool StringSet(string key, string value, TimeSpan? expiry);

        Task<bool> StringSetAsync(string key, string value, TimeSpan? expiry);

        bool Exists(string key);

        Task<bool> ExistsAsync(string key);
    }
}
