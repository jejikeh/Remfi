using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Common;

public enum RunningEnvironment
{
    Development,
    IntegrationTest,
    Production
}

public struct DatabaseConfiguration
{
    public enum DatabaseProvider
    {
        Sqlite,
        Postgresql
    }
    
    public DatabaseProvider Provider { get; }
    public string ConnectionString { get; }
    
    public DatabaseConfiguration(DatabaseProvider provider, string connectionString)
    {
        Provider = provider;
        ConnectionString = connectionString;
    }
}

public struct IdentityConfiguration 
{
    public IdentityOptions Options { get; }

    public IdentityConfiguration()
    {
        Options = new IdentityOptions();
    }
}