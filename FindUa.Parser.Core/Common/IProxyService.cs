using System.Net;

namespace FindUa.Parser.Core.Common
{
    public interface IProxyService
    {
        string GetRandomProxyUrlFromRedis();
    }
}
