
using FindUa.ProxyGrabber.Core;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.Domain.Services
{
    public class ProxyHealthChecker : IProxyHealthChecker
    {
        private ExtendedWebClient _webClient;

        public async Task<bool> IsWorking(string proxyUrl)
        {
            using (_webClient = new ExtendedWebClient())
            {
                try
                {
                    _webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36");
                    _webClient.Headers.Add("Accept-Language", "en-US,en;q=0.9,ru;q=0.8");
                    _webClient.Proxy = new WebProxy(proxyUrl);
                    _webClient.Timeout = 5000;

                    await _webClient.DownloadStringTaskAsync("https://rst.ua/oldcars/skoda/octavia/skoda_octavia_11086052.html");

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
