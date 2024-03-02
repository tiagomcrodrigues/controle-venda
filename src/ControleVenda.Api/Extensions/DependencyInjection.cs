using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace ControleVenda.Api.Extensions
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));
            return services;
        }

    }
}
