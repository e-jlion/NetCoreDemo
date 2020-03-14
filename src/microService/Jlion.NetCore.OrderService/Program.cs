using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Jlion.NetCore.OrderService.Service.Impls;
using System;
using static Jlion.NetCore.OrderService.Service.Grpc.JlionOrderService;

namespace Jlion.NetCore.OrderService.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HostBuilder()
               .UseConsoleLifetime() //使用控制台生命周期
               .ConfigureAppConfiguration((context, configuration) =>
               {
                   configuration
                   .AddJsonFile("appsettings.json", optional: true)
                   .AddEnvironmentVariables();
               })
               .ConfigureLogging(logger =>
               {
                   logger.AddFilter("Microsoft", LogLevel.Critical)
                         .AddFilter("System", LogLevel.Critical);
               })
               .ConfigureServices(ConfigureServices)
               .Build();

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var logFactory = host.Services.GetService<ILoggerFactory>();
                var logger = logFactory.CreateLogger<Program>();
                logger.LogError(e.ExceptionObject as Exception, $"UnhandledException");
            };

            host.Run();
        }

        /// <summary>
        /// 通用DI注入
        /// </summary>
        /// <param name="context"></param>
        /// <param name="services"></param>
        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            //HostedService 单例注入到DI 中
            services.AddSingleton<IHostedService, HostedService>();
            services.AddTransient<JlionOrderServiceBase, JlionOrderServiceImpl>();
        }
    }
}
