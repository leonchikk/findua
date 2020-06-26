using HtmlAgilityPack;
using System.Collections.Generic;

namespace FindUa.ProxyGrabber.Core
{
    public interface IProxyParseProvider
    {
        IEnumerable<string> GetProxies(HtmlNode htmlNode);
    }
}
