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
    }
}
