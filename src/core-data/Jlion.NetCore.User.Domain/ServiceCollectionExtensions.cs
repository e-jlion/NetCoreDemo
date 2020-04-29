using Jlion.NetCore.User.Domain.Contracts;
using Jlion.NetCore.User.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jlion.NetCore.User.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDomainDI(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
