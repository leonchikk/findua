using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.Core
{
    public interface IProxyParseProvider
    {
        Task<IEnumerable<string>> GetProxiesAsync();
    }
}
