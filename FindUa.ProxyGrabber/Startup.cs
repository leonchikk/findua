using Common.Core.Extensions;
using FindUa.ProxyGrabber.Settings.Interfaces;
using FindUa.ProxyGrabber.Settings.Models;
using FindUa.ProxyGrabber.Settings.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FindUa.ProxyGrabber
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var proxyGrabberSettings = Configuration.GetSection("ProxyGrabberSettings");
            services.AddOptions();
            services.Configure<ProxyGrabberSettings>(proxyGrabberSettings);

            services.AddSingleton<IProxyGrabberSettingsService, ProxyGrabberSettingsService>();
            services.AddRedisCache();

            services.AddHostedService<ProxyGrabberBackgroundWorker>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
        }
    }
}
