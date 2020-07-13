using Common.Core;
using FindUa.Parser.Core;
using FindUa.Parser.Core.Common;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FindUa.RstParser.Domain
{
    public class DataLoader : IDataLoader
    {
        private readonly ExtendedWebClient _webClient;
        private readonly IProxyService _proxyService;
        private readonly ILogger<DataLoader> _logger;

        public DataLoader(IProxyService proxyService, ILogger<DataLoader> logger)
        {
            _webClient = new ExtendedWebClient();
            _proxyService = proxyService;
            _logger = logger;
        }

        public async Task<HtmlDocument> LoadHtmlDocumentAsync(string url)
        {
            var proxyUrl = _proxyService.GetRandomProxyUrlFromRedis();

            _webClient.Proxy = new WebProxy(proxyUrl);
            _webClient.Timeout = 10000;
            _webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36");
            _webClient.Headers.Add("Accept-Language", "en-US,en;q=0.9,ru;q=0.8");
            _webClient.Encoding = Encoding.GetEncoding(1251);

            _logger.LogInformation($"Make request to {url} , using proxy: {proxyUrl}");
            string htmlString = await _webClient.DownloadStringTaskAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            return htmlDoc;
        }
    }
}
