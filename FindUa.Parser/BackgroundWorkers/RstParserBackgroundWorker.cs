using FindUa.Parser.Core.Common;
using FindUa.Parser.Settings.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FindUa.Parser.BackgroundWorkers
{
    public class RstParserBackgroundWorker : BackgroundService
    {
        private readonly ILogger<RstParserBackgroundWorker> _logger;
        private readonly IParserSettingsService _settingsService;
        private readonly IMemoryStore _memoryStore;

        public RstParserBackgroundWorker(
            ILogger<RstParserBackgroundWorker> logger,
            IParserSettingsService settingsService,
            IMemoryStore memoryStore)
        {
            _logger = logger;
            _settingsService = settingsService;
            _memoryStore = memoryStore;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Thread {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(_settingsService.GetDelayBetweenStepsInMilliseconds(), stoppingToken);
            }
        }
    }
}
