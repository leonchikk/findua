using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FindUa.ProxyGrabber.Core;
using FindUa.ProxyGrabber.Settings.Interfaces;
using Microsoft.Extensions.Hosting;

namespace FindUa.ProxyGrabber.BackgroundWorkers
{
    public class ProxyGrabberBackgroundWorker : BackgroundService
    {
        private readonly IEnumerable<IProxyParseProvider> _proxyParseProviders;
        private readonly IProxyGrabberSettingsService _settings;
        private readonly IProxyHealthChecker _proxyHealthChecker;
        private readonly IProxyService _proxyService;

        public ProxyGrabberBackgroundWorker
        (
            IEnumerable<IProxyParseProvider> proxyParseProviders,
            IProxyGrabberSettingsService settings,
            IProxyHealthChecker proxyHealthChecker,
            IProxyService proxyService
        )
        {
            _proxyParseProviders = proxyParseProviders;
            _proxyHealthChecker = proxyHealthChecker;
            _proxyService = proxyService;
            _settings = settings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _proxyService.WriteToRedisExistingProxiesFromFile();

            while (!stoppingToken.IsCancellationRequested)
            {
                var parsedProxies = new List<string>();

                foreach (var proxyParseProvider in _proxyParseProviders)
                {
                    parsedProxies.AddRange(await proxyParseProvider.GetProxiesAsync());
                }

                for (int i = 0; i < parsedProxies.Count; i++)
                {
                    var proxy = parsedProxies[i];
                    var isWorking = await _proxyHealthChecker.IsWorking(proxy);

                    if (isWorking)
                    {
                        _proxyService.SaveProxyToRedis(proxy);
                        _proxyService.SaveProxyToFile(proxy);
                    }
                }

                await Task.Delay(_settings.GetDelayBetweenGrabbing());
            }
        }
    }
}
