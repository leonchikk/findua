using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.Core
{
    public interface IProxyHealthChecker
    {
        Task<bool> IsWorking(string proxyUrl);
    }
}
