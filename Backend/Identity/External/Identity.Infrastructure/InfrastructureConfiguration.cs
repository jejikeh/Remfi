using Identity.Infrastructure.Common;
using Identity.Infrastructure.Common.Injections;
using Identity.Infrastructure.Configuration;
using Identity.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IApplicationConfiguration applicationConfiguration)
    {
        return services
            .AddDatabaseProvider(applicationConfiguration.DatabaseConfiguration)
            .AddRepositories()
            .AddIdentity(applicationConfiguration.IdentityConfiguration)
            .AddEmailServices();
    }

    private static IServiceCollection AddDatabaseProvider(this IServiceCollection services, DatabaseConfiguration databaseConfiguration)
    {
        return databaseConfiguration.Provider switch
        {
            DatabaseConfiguration.DatabaseProvider.Sqlite => services.AddSqliteDatabaseProvider(databaseConfiguration.ConnectionString),
            DatabaseConfiguration.DatabaseProvider.Postgresql => services.AddPostgresqlDatabaseProvider(databaseConfiguration.ConnectionString),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}