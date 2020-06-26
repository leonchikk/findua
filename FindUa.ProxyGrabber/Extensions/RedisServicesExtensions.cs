using CachingFramework.Redis;
using CachingFramework.Redis.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Collections.Generic;

namespace FindUa.ProxyGrabber.Extensions
{
    public static class RedisServicesExtensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services)
        {

            services.AddSingleton<IContext>((serviceProvider) =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();

                var configurationOptions = new ConfigurationOptions
                {
                    AbortOnConnectFail = true,
                    AllowAdmin = true,
                    EndPoints = { configuration.GetValue<string>("DistributedCacheRedis:Configuration") },
                    Ssl = configuration.GetValue<bool>("DistributedCacheRedis:Ssl"),
                    ConnectRetry = configuration.GetValue<int>("DistributedCacheRedis:ConnectRetry"),
                    ConnectTimeout = configuration.GetValue<int>("DistributedCacheRedis:ConnectTimeout"),
                    SyncTimeout = configuration.GetValue<int>("DistributedCacheRedis:SyncTimeout")
                };

                var redis = new RedisContext(configurationOptions);

                return redis;
            });

            return services;
        }
    }
}
