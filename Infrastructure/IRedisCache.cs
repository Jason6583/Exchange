using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRedisCache
    {
        RedisValue Get(string key);

        Task<RedisValue> GetAsync(string key);

        bool Set(string key, string value, TimeSpan? expiry);

        Task<bool> SetAsync(string key, string value, TimeSpan? expiry);

        bool Exists(string key);

        Task<bool> ExistsAsync(string key);
    }
}
