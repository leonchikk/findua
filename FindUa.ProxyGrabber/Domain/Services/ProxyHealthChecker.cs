
using Common.Core;
using FindUa.ProxyGrabber.Core;
using FindUa.ProxyGrabber.Settings.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.Domain.Services
{
    public class ProxyHealthChecker : IProxyHealthChecker
    {
        private ExtendedWebClient _webClient;

        private readonly IProxyGrabberSettingsService _settings;

        public ProxyHealthChecker(IProxyGrabberSettingsService settings)
        {
            _settings = settings;
        }

        public async Task<(string proxyUrl, bool isWorking)> IsWorking(string proxyUrl)
        {
            using (_webClient = new ExtendedWebClient())
            {
                try
                {
                    _webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36");
                    _webClient.Headers.Add("Accept-Language", "en-US,en;q=0.9,ru;q=0.8");
                    _webClient.Proxy = new WebProxy(proxyUrl);
                    _webClient.Timeout = _settings.GetAllowedTimeoutForProxy();

                    foreach (var url in _settings.GetUrlsForCheck())
                    {
                        await _webClient.DownloadStringTaskAsync(url);
                    }

                    return (proxyUrl, isWorking: true);
                }
                catch (Exception ex)
                {
                    return (proxyUrl, isWorking: false);
                }
            }
        }
    }
}
