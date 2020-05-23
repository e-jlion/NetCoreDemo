using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jlion.NetCore.HttpClient.DemoService.Handler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Jlion.NetCore.HttpClient.DemoService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddHttpClient();
            services.AddHttpClient("test")
                 .ConfigurePrimaryHttpMessageHandler(provider =>
                 {
                     var handler = new PrimaryHttpMessageHandler(provider);
                     return handler;
                 })
                 .AddHttpMessageHandler(provider =>
                 {
                     return new LogHttpMessageHandler(provider);
                 })
                 .AddHttpMessageHandler(provider =>
                 {
                    return new Log2HttpMessageHandler(provider);
                 });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
