using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jlion.NetCore.Identity.Service.Validator;
using Jlion.NetCore.Identity.UserApiService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Jlion.NetCore.Identity.Service
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

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            #region 内存方式
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryApiResources(OAuthMemoryData.GetApiResources())
            //    .AddInMemoryClients(OAuthMemoryData.GetClients())
            //    .AddTestUsers(OAuthMemoryData.GetTestUsers());
            #endregion

            #region 数据库存储方式
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(OAuthMemoryData.GetApiResources())
                //.AddInMemoryClients(OAuthMemoryData.GetClients())
                .AddClientStore<ClientStore>()
                //.AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddResourceOwnerValidator<RoleTestResourceOwnerPasswordValidator>()
                .AddExtensionGrantValidator<WeiXinOpenGrantValidator>()
                .AddProfileService<UserProfileService>();//添加微信端自定义方式的验证
            #endregion

            #region 单点登录方式 Demo

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCookiePolicy();
            app.UseIdentityServer();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
