using FindUa.Parser.Core.Common;
using HtmlAgilityPack;
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
            _httpClient = new HttpClient();
        }

        public async Task<HtmlDocument> LoadHtmlDocumentAsync(string url)
        {
            using (var getRequest = new HttpRequestMessage(HttpMethod.Get, url))
            {
                getRequest.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36");

                var response = await _httpClient.SendAsync(getRequest);
                byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();
                string htmlString =Encoding.GetEncoding(1251).GetString(responseBytes);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlString);

                return htmlDoc;
            }
        }
    }
}
