using FindUa.ProxyGrabber.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.Domain.ProxyParseProviders.FreeProxyListNet
{
    public class FreeProxyListNetProxyParseProvider : IProxyParseProvider
    {
        private IDataLoader _dataLoader;

        public FreeProxyListNetProxyParseProvider(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public async Task<IEnumerable<string>> GetProxiesAsync()
        {
            var html = await _dataLoader.LoadHtmlDocumentAsync("https://free-proxy-list.net/");

            var regex = new Regex(@"((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?):\d+");
            var proxyAddresses = regex.Matches(html.DocumentNode.InnerText)
                                      .Select(match => match.Value);

            return proxyAddresses;
        }
    }
}
