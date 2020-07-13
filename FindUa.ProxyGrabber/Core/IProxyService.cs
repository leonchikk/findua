using System.Collections.Generic;

namespace FindUa.ProxyGrabber.Core
{
    public interface IProxyService
    {
        void WriteToRedisExistingProxiesFromFile();
        void SaveProxyToFile(string proxyUrl);
        void SaveProxyToFile(IEnumerable<string> proxyUrls);
        void SaveProxyToRedis(string proxyUrl);
        void SaveProxyToRedis(IEnumerable<string> proxyUrls);
        void RemoveFromFile(string proxyUrl);
        void RemoveFromRedis(string proxyUrl);
        bool IsAlreadyExists(string proxyUrl);

        IEnumerable<string> GetProxiesFromFile();
        IEnumerable<string> GetProxiesFromRedis();
    }
}
