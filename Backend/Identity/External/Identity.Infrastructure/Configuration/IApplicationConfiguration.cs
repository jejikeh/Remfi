namespace Identity.Infrastructure.Configuration;

public interface IApplicationConfiguration
{
    public DatabaseConfiguration DatabaseConfiguration { get; }
    public IdentityConfiguration IdentityConfiguration { get; }
    public EmailSmtpConfiguration EmailSmtpConfiguration { get; }
    public ApplicationEnvironmentConfiguration ApplicationEnvironmentConfiguration { get; }
}