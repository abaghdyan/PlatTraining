using Microsoft.Extensions.DependencyInjection;
using PlatTraining.Services.Contracts;
using PlatTraining.Services.Impl;

namespace PlatTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPlatIndexService, PlatIndexService>();

            return services;
        }
    }
}
