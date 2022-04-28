using Microsoft.Extensions.DependencyInjection;
using PlatTraining.Services.Contracts;

namespace PlatTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPlatIndexService, PlatIndexService>();

            return services;
        }
    }
}
