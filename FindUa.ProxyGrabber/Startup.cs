using FindUa.ProxyGrabber.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FindUa.ProxyGrabber
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRedisCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
        }
    }
}
