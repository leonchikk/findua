using FindUa.ProxyGrabber.Core;
using HtmlAgilityPack;
using System.Net;
using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.Domain.Services
{
    public class DataLoader : IDataLoader
    {
        private WebClient _webClient;

        public async Task<HtmlDocument> LoadHtmlDocumentAsync(string url)
        {
            using (_webClient = new WebClient())
            {
                _webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36");
                _webClient.Headers.Add("Accept-Language", "en-US,en;q=0.9,ru;q=0.8");

                var htmlString = await _webClient.DownloadStringTaskAsync(url);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlString);

                return htmlDoc;
            }
        }
    }
}
