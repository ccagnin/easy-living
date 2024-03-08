using System.Reflection;
using EasyLiving.Application.Auth.Commands.Register;
using EasyLiving.Application.Auth.Commom;
using EasyLiving.Application.Commom.Behaviors;
using MediatR;
using ErrorOr;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EasyLiving.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); 
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            return services;
        }
    }
}
