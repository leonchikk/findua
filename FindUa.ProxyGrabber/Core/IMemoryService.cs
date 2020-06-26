using System.Collections.Generic;

namespace FindUa.ProxyGrabber.Core
{
    public interface IMemoryService
    {
        void SaveProxy(string url);
        void SaveProxy(IEnumerable<string> urls);
    }
}
