using PlatTraining.Options;

namespace PlatTraining
{
    public static class OptionsExtensions
    {
        public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EnvironmentOptions>(configuration.GetSection(EnvironmentOptions.Section));

            return services;
        }
    }
}
