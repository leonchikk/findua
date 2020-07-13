using CachingFramework.Redis.Contracts;
using CachingFramework.Redis.Contracts.RedisObjects;
using Common.Core.CacheKeys;
using FindUa.ProxyGrabber.Core;
using FindUa.ProxyGrabber.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FindUa.ProxyGrabber.Domain.Services
{
    public class ProxyService : IProxyService
    {
        private readonly IContext _redisContext;
        private readonly IRedisSet<string> _proxiesSet;
        private readonly IProxyGrabberSettingsService _settings;

        public ProxyService(IContext redisContext, IProxyGrabberSettingsService settings)
        {
            _redisContext = redisContext;
            _settings = settings;
            _proxiesSet = _redisContext.Collections.GetRedisSet<string>(CacheKeys.Proxy);
        }

        public void WriteToRedisExistingProxiesFromFile()
        {
            var proxies = GetProxiesFromFile();
            SaveProxyToRedis(proxies);
        }

        public void SaveProxyToFile(string proxyUrl)
        {
            File.AppendAllText(_settings.GetProxyFilePath(), proxyUrl + Environment.NewLine);
        }

        public void SaveProxyToFile(IEnumerable<string> proxyUrls)
        {
            foreach (var proxy in proxyUrls)
            {
                SaveProxyToFile(proxy);
            }
        }

        public void SaveProxyToRedis(string url)
        {
            _proxiesSet.Add(url);
        }

        public void SaveProxyToRedis(IEnumerable<string> urls)
        {
            _proxiesSet.AddRange(urls);
        }

        public void RemoveFromFile(string proxyUrl)
        {
            var proxies = File.ReadAllLines(_settings.GetProxyFilePath()).ToList();
            proxies.Remove(proxyUrl);
            File.WriteAllLines(_settings.GetProxyFilePath(), proxies);
        }

        public void RemoveFromRedis(string proxyUrl)
        {
            _proxiesSet.Remove(proxyUrl);
        }

        public IEnumerable<string> GetProxiesFromFile()
        {
            return File.ReadAllLines(_settings.GetProxyFilePath());
        }

        public bool IsAlreadyExists(string proxyUrl)
        {
            return _proxiesSet.Any(x => x == proxyUrl);
        }

        public IEnumerable<string> GetProxiesFromRedis()
        {
            return _proxiesSet;
        }
    }
}
