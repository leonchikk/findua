using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace FindUa.ProxyGrabber.BackgroundWorkers
{
    public class ProxyGrabberBackgroundWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
