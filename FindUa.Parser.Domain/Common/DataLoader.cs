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
            //149.13.94.38:80
            var handler = new HttpClientHandler()
            {
                //
                Proxy = new WebProxy("68.183.178.145:3128"),
                UseProxy = true,
            };

            _httpClient = new HttpClient(handler);
        }

        public async Task<HtmlDocument> LoadHtmlDocumentAsync(string url)
        {
            using (var getRequest = new HttpRequestMessage(HttpMethod.Get, url))
            {
                getRequest.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36");
                getRequest.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9,ru;q=0.8");

                var response = await _httpClient.SendAsync(getRequest);

                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new Exception("Get request has been failed. 403 - status response");
                }

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new Exception("Get request has been failed. 400 - status response");
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Get request has been failed. Status code is {response.StatusCode}");
                }

                byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();
                string htmlString = Encoding.GetEncoding(1251).GetString(responseBytes);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlString);

                return htmlDoc;
            }
        }
    }
}
