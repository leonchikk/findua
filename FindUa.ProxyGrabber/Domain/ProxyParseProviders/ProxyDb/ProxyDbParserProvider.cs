using FindUa.ProxyGrabber.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.Domain.ProxyParseProviders.ProxyDb
{
    public class ProxyDbParserProvider : IProxyParseProvider
    {
        private readonly IDataLoader _dataLoader;
        private int _offset;

        public ProxyDbParserProvider(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
            _offset = 15;
        }

        public async Task<IEnumerable<string>> GetProxiesAsync()
        {
            var parsedProxies = new List<string>();
            var pageCountPerStep = 10;

            for (int i = 0; i < pageCountPerStep; i++)
            {
                var encodedFormData = $"offset={_offset}&g-recaptcha-response=03AGdBq26KBZEYbfddgPqKVeJl3oK_dl71Hhla1QxoC499CZ8R9yhNG7qdqq22wQgHpG7KZ0rC8cML1S-hIF-WsFOkgea7MDVA-Uo8OfApJJIHvIZ9JO15nTHCwjuGgwkpE6H8d01EAwgvoLTx51Dz1AeIX7b8xxfxs_8NvAybZfjgE3v2_Yvpvc4fDp9bwxwYp-5OkFYmP9nRy2d3_bQc6GgbjYP1NHul2k3FQBdmbSK9pMbwDdeNVKc8iWSJDbncVx5uwI0Y4Dazj1If9FSYEg-wkIGNX62Hwwkwrtu9QldoJ3_YTibRb7t5e1QU5JWfxU4AyPOyhuKZgFVbVeEvuoZZaG4ofSVASAfK5Cbp78pzFM3hWeNVY1atWi2Oyp5i2rkIHQ2AGeGt";
                var html = await _dataLoader.LoadHtmlDocumentWithFormDataAsync("http://proxydb.net/?protocol=https&country=", encodedFormData);

                var regex = new Regex(@"((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?):\d+");
                var proxyAddresses = regex.Matches(html.DocumentNode.InnerText)
                                          .Select(match => match.Value);

                parsedProxies.AddRange(proxyAddresses);
                _offset += 15;
            }

            return parsedProxies;
        }
    }
}
