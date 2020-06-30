using FindUa.ProxyGrabber.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.Domain.ProxyParseProviders.Spys
{
    public class SpysProxyParserProvider : IProxyParseProvider
    {
        private readonly IDataLoader _dataLoader;

        public SpysProxyParserProvider(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public async Task<IEnumerable<string>> GetProxiesAsync()
        {
            var parsedProxies = new List<string>();
            var html = await _dataLoader.LoadHtmlDocumentAsync("http://spys.me/proxy.txt");

            var regex = new Regex(@"((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?):\d+");
            var proxyAddresses = regex.Matches(html.DocumentNode.InnerText)
                                        .Select(match => match.Value);

            parsedProxies.AddRange(proxyAddresses);

            return parsedProxies;
        }
    }
}
