using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.Core
{
    public interface IProxyHealthChecker
    {
        Task<(string proxyUrl, bool isWorking)> IsWorking(string proxyUrl);
    }
}
