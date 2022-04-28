using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatTraining.Dal;

namespace PlatTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlatDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PlatDbContext>(options =>
                    options.UseSqlServer(connectionString));

            return services;
        }
    }
}
