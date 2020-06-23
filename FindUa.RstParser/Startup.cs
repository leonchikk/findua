using Common.Core.Interfaces;
using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
using FindUa.RstParser.BackgroundWorkers;
using FindUa.RstParser.Data.Contexts;
using FindUa.RstParser.Data.Repositories;
using FindUa.RstParser.Domain.Common;
using FindUa.RstParser.Domain.Extensions;
using FindUa.RstParser.Settings.Interfaces;
using FindUa.RstParser.Settings.Models;
using FindUa.RstParser.Settings.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FindUa.RstParser
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
            services.AddSingleton<IMemoryStore>(serviceProvider =>
            {
                var scope = serviceProvider.CreateScope();
                var unitOfWork = scope.ServiceProvider.GetService<IUnitOfWork>();
                var memoryStore = new MemoryStore(unitOfWork);
                memoryStore.LoadDataAsync()
                            .ConfigureAwait(false)
                            .GetAwaiter()
                            .GetResult();

                return memoryStore;
            });

            var parserSettings = Configuration.GetSection("ParserSettings");
            services.AddOptions();
            services.Configure<ParserSettings>(parserSettings);

            services.AddHostedService<RstParserBackgroundWorker>();

            services.AddRstParser(); 
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
