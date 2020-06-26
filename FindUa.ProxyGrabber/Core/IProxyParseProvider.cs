using HtmlAgilityPack;

namespace FindUa.ProxyGrabber.Core
{
    public interface IProxyParseProvider
    {
        string GetProxy(HtmlNode htmlNode);
    }
}
