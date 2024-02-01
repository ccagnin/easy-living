using EasyLiving.Application.Commom.Interfaces.Services;
using EasyLiving.Application.Common.Interfaces.Auth;
using EasyLiving.Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace EasyLiving.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddSingleton<IJwtToken, JwtToken>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
