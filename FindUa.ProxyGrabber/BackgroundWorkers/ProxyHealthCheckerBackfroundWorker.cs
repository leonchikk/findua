using FindUa.ProxyGrabber.Core;
using FindUa.ProxyGrabber.Settings.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        private readonly IDictionary<string, int> _candidatesToRemove;

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
            _candidatesToRemove = new Dictionary<string, int>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(_settings.GetHealthCheckFrequencyInMilliseconds());

                    _logger.LogInformation($"Started work to check proxy healthy");

                    var existsProxies = _proxyService.GetProxiesFromRedis().ToList();

                    for (int i = 0; i < existsProxies.Count; i++)
                    {
                        var proxyUrl = existsProxies[i];

                        var isWorking = await _proxyHealthChecker.IsWorking(proxyUrl);
                        var isCandidateToDelete = _candidatesToRemove.Any(x => x.Key == proxyUrl);

                        if (isWorking && isCandidateToDelete)
                            _candidatesToRemove[proxyUrl] = 0;
                        

                        if (!isWorking)
                        {
                            if (!isCandidateToDelete)
                                _candidatesToRemove.Add(proxyUrl, 1);

                            else
                            {
                                var currentAttemptCount = _candidatesToRemove[proxyUrl];
                                currentAttemptCount += 1;

                                if (currentAttemptCount >= _settings.GetFailedHealthCheckAttemptCount())
                                {
                                    _proxyService.RemoveFromFile(proxyUrl);
                                    _proxyService.RemoveFromRedis(proxyUrl);

                                    _logger.LogInformation($"Removed {proxyUrl}, it has failed checking {_settings.GetFailedHealthCheckAttemptCount()} times");
                                }
                            }
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
