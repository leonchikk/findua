using FindUa.Parser.Core.Common;
using HtmlAgilityPack;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FindUa.Parser.Domain.Common
{
    public class DataLoader : IDataLoader
    {
        private readonly HttpClient _httpClient;

        public DataLoader()
        {
            var handler = new HttpClientHandler()
            {
                Proxy = new WebProxy("209.41.69.101:3128"),
                UseProxy = true,
            };

            _httpClient = new HttpClient(handler);
        }

        //_webClient.Proxy = new WebProxy("85.172.104.162", 8000);
        public async Task<HtmlDocument> LoadHtmlDocumentAsync(string url)
        {
            using (var getRequest = new HttpRequestMessage(HttpMethod.Get, url))
            {
                getRequest.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36");

                var response = await _httpClient.SendAsync(getRequest);
                byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();
                string htmlString = Encoding.GetEncoding(1251).GetString(responseBytes);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlString);

                return htmlDoc;
            }
        }
    }
}
