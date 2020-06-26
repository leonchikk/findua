using System.Threading;
using System.Threading.Tasks;
using FindUa.ProxyGrabber.Core;
using Microsoft.Extensions.Hosting;

namespace FindUa.ProxyGrabber.BackgroundWorkers
{
    public class ProxyGrabberBackgroundWorker : BackgroundService
    {
        private readonly IMemoryService _memoryService;

        public ProxyGrabberBackgroundWorker(IMemoryService memoryService)
        {
            _memoryService = memoryService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
        }
    }
}
