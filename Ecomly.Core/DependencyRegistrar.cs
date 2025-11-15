using Microsoft.Extensions.DependencyInjection;

namespace Ecomly.Core
{
    public static class DependencyRegistrar
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            return services;
        }
    }
}
