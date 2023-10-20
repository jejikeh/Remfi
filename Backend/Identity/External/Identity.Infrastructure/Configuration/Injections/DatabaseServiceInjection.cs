using System.Reflection;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure.Common.Injections;

public static class DatabaseServiceInjection
{
    public static IServiceCollection AddSqliteDatabaseProvider(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<IdentityContext>(options =>
        {
            options.UseSqlite(
                connectionString, 
                sqliteDbContextOptionsBuilder => sqliteDbContextOptionsBuilder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
        });

        return services;
    }

    public static IServiceCollection AddPostgresqlDatabaseProvider(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<IdentityContext>(options =>
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            
            options.UseNpgsql(
                connectionString, 
                builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)
            );
        });

        return services;
    }
}