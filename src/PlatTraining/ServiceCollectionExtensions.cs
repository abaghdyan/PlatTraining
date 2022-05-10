using PlatTraining.Options;

namespace PlatTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IndexOptions>(configuration.GetSection(IndexOptions.Section));

            return services;
        }
    }
}
