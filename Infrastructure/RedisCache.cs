using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class RedisCache : IRedisCache
    {
        private readonly object lockObject;
        private ConnectionMultiplexer _connectionMultiplexer;
        private readonly string _connectionString;
        private ConnectionMultiplexer ConnectionMultiplexer
        {
            get
            {
                if (_connectionMultiplexer == null) //this check avoids unnecessary locking
                {
                    lock (lockObject)
                    {
                        if (_connectionMultiplexer == null)
                        {
                            _connectionMultiplexer = ConnectionMultiplexer.Connect(_connectionString);
                        }
                    }
                }
                return _connectionMultiplexer;
            }
        }
        public RedisCache(string connectionString)
        {
            _connectionString = connectionString;
            lockObject = new object();
        }

        public RedisValue Get(string key)
        {
            return ConnectionMultiplexer.GetDatabase().StringGet(key);
        }

        public async Task<RedisValue> GetAsync(string key)
        {
            return await ConnectionMultiplexer.GetDatabase().StringGetAsync(key);
        }

        public bool Set(string key, string value, TimeSpan? expiry)
        {
            return ConnectionMultiplexer.GetDatabase().StringSet(key, value, expiry);
        }

        public async Task<bool> SetAsync(string key, string value, TimeSpan? expiry)
        {
            return await ConnectionMultiplexer.GetDatabase().StringSetAsync(key, value, expiry);
        }

        public bool Exists(string key)
        {
            return ConnectionMultiplexer.GetDatabase().KeyExists(key);
        }

        public async Task<bool> ExistsAsync(string key)
        {
            return await ConnectionMultiplexer.GetDatabase().KeyExistsAsync(key);
        }
    }
}
