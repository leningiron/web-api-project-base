using Base.Lgm.Business.Impl;
using Base.Lgm.Core.Interfaces.Business;
using Base.Lgm.Core.Interfaces.Repositories;
using Base.Lgm.Core.Models.Static;
using Base.Lgm.Repositories;
using Base.Lgm.WebApi.Filters;
using ExternalBase.Lgm.Utilities.Impl.ErrorFactory;
using ExternalBase.Lgm.Utilities.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Base.Lgm.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IHttpErrorFactory, DefaultHttpErrorFactory>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IUserBusiness, UserBusiness>();

            return services;
        }

        public static IServiceCollection AddCustomFilter(this IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, HostStartupFilter>();

            return services;
        }
        public static IServiceCollection AddCustomConfigure(this IServiceCollection services,
           IConfiguration configuration)
        {
            SettingDataBaseSt.ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");

            return services;
        }
    }
}
