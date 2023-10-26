using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Configuration;

public enum RunningEnvironment
{
    Development,
    IntegrationTest,
    Production
}

public struct ApplicationEnvironmentConfiguration
{
    public RunningEnvironment Environment { get; }
    public string Host { get; }

    public ApplicationEnvironmentConfiguration(RunningEnvironment environment, string host)
    {
        Environment = environment;
        Host = host;
    }
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

public struct EmailSmtpConfiguration
{
    public string Host { get; }
    public int Port { get; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string From { get; set; }

    public EmailSmtpConfiguration(string host, int port, string username, string password, string from)
    {
        Host = host;
        Port = port;
        Username = username;
        Password = password;
        From = from;
    }
}