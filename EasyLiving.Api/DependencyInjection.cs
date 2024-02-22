using EasyLiving.Api.Commom.Errors;
using EasyLiving.Api.Commom.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EasyLiving.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMapping();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, EasyLivingProblemDetailsFactory>();
        return services;
    }
}