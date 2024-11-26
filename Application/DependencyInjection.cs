using Application.Abstractions.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

                config.AddOpenBehavior(typeof(ValidationBehavior<,>));

            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
            
        }
    }
}
