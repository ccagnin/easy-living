using EasyLiving.Application.Commom.Interfaces.Auth;
using EasyLiving.Application.Commom.Interfaces.Persistence;
using EasyLiving.Application.Commom.Interfaces.Services;
using EasyLiving.Infrastructure.Auth;
using EasyLiving.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace EasyLiving.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtToken, JwtToken>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
