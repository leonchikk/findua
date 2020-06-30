using FindUa.ProxyGrabber.Core;
using FindUa.ProxyGrabber.Settings.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.BackgroundWorkers
{
    public class ProxyHealthCheckerBackfroundWorker : BackgroundService
    {
        private readonly IProxyService _proxyService;
        private readonly IProxyHealthChecker _proxyHealthChecker;
        private readonly IProxyGrabberSettingsService _settings;
        private readonly ILogger<ProxyHealthCheckerBackfroundWorker> _logger;

        public ProxyHealthCheckerBackfroundWorker
            (
                IProxyService proxyService, 
                IProxyHealthChecker proxyHealthChecker,
                IProxyGrabberSettingsService settings,
                ILogger<ProxyHealthCheckerBackfroundWorker> logger
            )
        {
            _proxyService = proxyService;
            _proxyHealthChecker = proxyHealthChecker;
            _settings = settings;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(_settings.GetHealthCheckFrequencyInMilliseconds());

                    var existsProxies = _proxyService.GetProxiesFromFile().ToList();

                    for (int i = 0; i < existsProxies.Count; i++)
                    {
                        var proxyUrl = existsProxies[i];

                        var isStillWorking = await _proxyHealthChecker.IsWorking(proxyUrl);

                        if (!isStillWorking)
                        {
                            _proxyService.RemoveFromFile(proxyUrl);
                            _proxyService.RemoveFromRedis(proxyUrl);
                        }
                    }
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message + "\n" + ex.StackTrace);
                }
            }
        }
    }
}
