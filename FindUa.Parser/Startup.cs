using Common.Core.Interfaces;
using FindUa.Parser.BackgroundWorkers;
using FindUa.Parser.Data.Contexts;
using FindUa.Parser.Data.Repositories;
using FindUa.Parser.Settings.Interfaces;
using FindUa.Parser.Settings.Models;
using FindUa.Parser.Settings.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FindUa.Parser
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
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddDbContext<TransportParserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("local")));

            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IParserSettingsService, ParserSettingsService>();

            var parserSettings = Configuration.GetSection("ParserSettings");
            services.AddOptions();
            services.Configure<ParserSettings>(parserSettings);

            services.AddHostedService<RstParserBackgroundWorker>();        
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseMvc();
        }
    }
}
