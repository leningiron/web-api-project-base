using Base.Lgm.Core.Interfaces.Repositories;
using Base.Lgm.Repositories.Impl;
using Base.Lgm.WebApi.Filters;
using ExternalBase.Lgm.Utilities.Impl.ErrorFactory;
using ExternalBase.Lgm.Utilities.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Lgm.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IHttpErrorFactory, DefaultHttpErrorFactory>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddCustomFilter(this IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, HostStartupFilter>();

            return services;
        }
    }
}
