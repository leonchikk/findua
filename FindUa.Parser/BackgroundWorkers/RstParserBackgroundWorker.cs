using FindUa.Parser.Domain.Common;
using FindUa.Parser.Settings.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindUa.Parser.BackgroundWorkers
{
    public class RstParserBackgroundWorker : BackgroundService
    {
        private readonly ILogger<RstParserBackgroundWorker> _logger;
        private readonly IParserSettingsService _settingsService;
        private readonly IServiceProvider _serviceProvider;

        public RstParserBackgroundWorker(
            ILogger<RstParserBackgroundWorker> logger,
            IParserSettingsService settingsService,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _settingsService = settingsService;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var processItemsCount = _settingsService.GetItemsCountForStep();
                var provider = ParserProviderFactory.CreateRtsParserProvider(scope)
                                                .SetDaysCountForProcessing(1)
                                                .SetItemsCountForStep(processItemsCount)
                                                .SetBaseUrl("https://rst.ua")
                                                .SetUrlForScrapping("https://rst.ua/oldcars/?make%5B%5D=0&year%5B%5D=0&year%5B%5D=0&price%5B%5D=0&price%5B%5D=0&engine%5B%5D=0&engine%5B%5D=0&gear=0&fuel=0&drive=0&condition=0&saled=0&notcust=-1&sort=1&task=newresults&from=sform");

                while (!stoppingToken.IsCancellationRequested)
                {
                    var start = DateTime.Now;

                    await provider.ProcessDataAsync();

                    var end = DateTime.Now;

                    _logger.LogInformation($"{processItemsCount} items processing occurs {(end - start).TotalMilliseconds} ms");

                    await Task.Delay(_settingsService.GetDelayBetweenStepsInMilliseconds(), stoppingToken);
                }
            }
        }
    }
}
