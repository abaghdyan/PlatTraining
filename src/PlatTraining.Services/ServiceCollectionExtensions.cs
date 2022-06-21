using Microsoft.Extensions.DependencyInjection;
using PlatTraining.Services.Contracts;
using PlatTraining.Services.Impl;

namespace PlatTraining.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IEmailHistoryService, EmailHistoryService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IGolbalUserService, GolbalUserService>();

            return services;
        }
    }
}
