using CachingFramework.Redis.Contracts;
using CachingFramework.Redis.Contracts.RedisObjects;
using Common.Core.CacheKeys;
using FindUa.ProxyGrabber.Core;
using System.Collections.Generic;

namespace FindUa.ProxyGrabber.Domain.Services
{
    public class MemoryService : IMemoryService
    {
        private readonly IContext _redisContext;
        private readonly IRedisSet<string> _proxiesSet;

        public MemoryService(IContext redisContext)
        {
            _redisContext = redisContext;
            _proxiesSet = _redisContext.Collections.GetRedisSet<string>(CacheKeys.Proxy);
        }

        public void SaveProxy(string url)
        {
            _proxiesSet.Add(url);
        }

        public void SaveProxy(IEnumerable<string> urls)
        {
            _proxiesSet.AddRange(urls);
        }
    }
}
