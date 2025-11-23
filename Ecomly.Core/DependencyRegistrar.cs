using Ecomly.Core.ServiceContracts;
using Ecomly.Core.Services;
using Ecomly.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ecomly.Core
{
    public static class DependencyRegistrar
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            return services;
        }
    }
}
