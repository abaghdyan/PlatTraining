using Microsoft.Extensions.DependencyInjection;
using PlatTraining.Services.Contracts;
using PlatTraining.Services.Impl;

namespace PlatTraining.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISomeTenantDataService, SomeTenantDataService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
