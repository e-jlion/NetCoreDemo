using Jlion.NetCore.User.Application.Constracts;
using Jlion.NetCore.User.Application.Services;
using Jlion.NetCore.User.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Jlion.NetCore.User.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationDI(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            services.AddDomainDI();
        }
    }
}
