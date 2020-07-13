using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FindUa.ProxyGrabber.Core;
using FindUa.ProxyGrabber.Settings.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FindUa.ProxyGrabber.BackgroundWorkers
{
    public class ProxyGrabberBackgroundWorker : BackgroundService
    {
        private readonly IEnumerable<IProxyParseProvider> _proxyParseProviders;
        private readonly IProxyGrabberSettingsService _settings;
        private readonly IProxyHealthChecker _proxyHealthChecker;
        private readonly IProxyService _proxyService;
        private readonly ILogger<ProxyGrabberBackgroundWorker> _logger;

        public ProxyGrabberBackgroundWorker
        (
            IEnumerable<IProxyParseProvider> proxyParseProviders,
            IProxyGrabberSettingsService settings,
            IProxyHealthChecker proxyHealthChecker,
            IProxyService proxyService,
            ILogger<ProxyGrabberBackgroundWorker> logger
        )
        {
            _proxyParseProviders = proxyParseProviders;
            _proxyHealthChecker = proxyHealthChecker;
            _proxyService = proxyService;
            _settings = settings;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _proxyService.WriteToRedisExistingProxiesFromFile();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var parsedProxies = new List<string>();

                    foreach (var proxyParseProvider in _proxyParseProviders)
                    {
                        parsedProxies.AddRange(await proxyParseProvider.GetProxiesAsync());
                    }

                    _logger.LogInformation($"Total amount of parsed proxies {parsedProxies.Count}");

                    for (int i = 0; i < parsedProxies.Count; i++)
                    {
                        var proxy = parsedProxies[i];
                        var isWorking = await _proxyHealthChecker.IsWorking(proxy);
                        var isAlreadyExists = _proxyService.IsAlreadyExists(proxy);

                        if (!isAlreadyExists && isWorking)
                        {
                            _proxyService.SaveProxyToRedis(proxy);
                            _proxyService.SaveProxyToFile(proxy);

                            _logger.LogInformation($"Added new proxy {proxy}");
                        }

                        if ((i % 50) == 0)
                        {
                            _logger.LogInformation($"Processed {i}/{parsedProxies.Count}");
                        }
                    }

                    await Task.Delay(_settings.GetDelayBetweenGrabbing());
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message + "\n" + ex.StackTrace);
                }
            }
        }
    }
}
