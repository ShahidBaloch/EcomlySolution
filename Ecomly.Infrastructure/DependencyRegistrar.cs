using Ecomly.Core.RepositoryContracts;
using Ecomly.Infrastructure.DbContext;
using Ecomly.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ecomly.Infrastructure;

public static class DependencyRegistrar
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();

        return services;
    }
}
