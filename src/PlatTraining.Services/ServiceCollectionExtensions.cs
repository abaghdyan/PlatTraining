using Microsoft.Extensions.DependencyInjection;
using PlatTraining.Data.Services;
using PlatTraining.Services.Contracts;
using PlatTraining.Services.Impl;

namespace PlatTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISomeTenantDataService, SomeTenantDataService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITenantResolver, TenantResolver>();

            return services;
        }
    }
}
