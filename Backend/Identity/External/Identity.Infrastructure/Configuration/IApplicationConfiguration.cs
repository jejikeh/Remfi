namespace Identity.Infrastructure.Common;

public interface IApplicationConfiguration
{
    public RunningEnvironment Environment { get; }
    public DatabaseConfiguration DatabaseConfiguration { get; }
    public IdentityConfiguration IdentityConfiguration { get; }
}