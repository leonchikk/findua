using Common.Core.Interfaces;
using FindUa.Parser.BackgroundWorkers;
using FindUa.Parser.Core.Common;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Data.Contexts;
using FindUa.Parser.Data.Repositories;
using FindUa.Parser.Domain.Common;
using FindUa.Parser.Settings.Interfaces;
using FindUa.Parser.Settings.Models;
using FindUa.Parser.Settings.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

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
            //services.AddHostedService<TestBW>();
        }

        public async void Configure(IApplicationBuilder app)
        {

        }
    }
}
