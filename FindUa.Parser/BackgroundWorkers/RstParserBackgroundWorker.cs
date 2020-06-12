using FindUa.Parser.Settings.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace FindUa.Parser.BackgroundWorkers
{
    public class RstParserBackgroundWorker : BackgroundService
    {
        private readonly ILogger<RstParserBackgroundWorker> _logger;
        private readonly IParserSettingsService _settingsService;

        public RstParserBackgroundWorker(
            ILogger<RstParserBackgroundWorker> logger,
            IParserSettingsService settingsService)
        {
            _logger = logger;
            _settingsService = settingsService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {


            }
        }
    }
}
