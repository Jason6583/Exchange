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

        public RedisValue StringGet(string key)
        {
            return ConnectionMultiplexer.GetDatabase().StringGet(key);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>")]
        public async Task<RedisValue> StringGetAsync(string key)
        {
            return await ConnectionMultiplexer.GetDatabase().StringGetAsync(key);
        }

        public bool StringSet(string key, string value, TimeSpan? expiry)
        {
            return ConnectionMultiplexer.GetDatabase().StringSet(key, value, expiry);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>")]
        public async Task<bool> StringSetAsync(string key, string value, TimeSpan? expiry)
        {
            return await ConnectionMultiplexer.GetDatabase().StringSetAsync(key, value, expiry);
        }

        public bool Exists(string key)
        {
            return ConnectionMultiplexer.GetDatabase().KeyExists(key);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>")]
        public async Task<bool> ExistsAsync(string key)
        {
            return await ConnectionMultiplexer.GetDatabase().KeyExistsAsync(key);
        }
    }
}
