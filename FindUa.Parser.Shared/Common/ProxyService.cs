using CachingFramework.Redis.Contracts;
using Common.Core.CacheKeys;
using FindUa.Parser.Core.Common;
using System;
using System.Linq;
using System.Net;

namespace FindUa.Parser.Shared.Common
{
    public class ProxyService : IProxyService
    {
        private readonly IContext _redisContext;

        public ProxyService(IContext redisContext)
        {
            _redisContext = redisContext;
        }

        public string GetRandomProxyUrlFromRedis()
        {
            var proxiesSet = _redisContext.Collections.GetRedisSet<string>(CacheKeys.Proxy).ToList();

            if (!proxiesSet.Any())
                throw new WebException("Proxies list is empty");

            var randomizer = new Random();
            var randomProxyIndex = randomizer.Next(0, proxiesSet.Count - 1);

            return proxiesSet[randomProxyIndex];
        }
    }
}
