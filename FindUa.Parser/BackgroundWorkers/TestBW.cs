using FindUa.Parser.Core.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindUa.Parser.BackgroundWorkers
{
    public class TestBW : BackgroundService
    {
        private readonly ILogger<TestBW> _logger;
        private readonly IServiceProvider _serviceProvider;
        public TestBW(
            ILogger<TestBW> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var memoryStore = scope.ServiceProvider.GetService<IMemoryStore>();
                await memoryStore.LoadDataAsync();

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation($"Thread {Thread.CurrentThread.ManagedThreadId}");
                    await Task.Delay(2000);

                }
            }
        }
    }
}
