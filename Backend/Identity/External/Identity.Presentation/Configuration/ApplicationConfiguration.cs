using Identity.Infrastructure.Common;
using Identity.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity;

namespace Identity.Presentation.Configuration;

public class ApplicationConfiguration : IApplicationConfiguration
{
    public DatabaseConfiguration DatabaseConfiguration { get; }
    public IdentityConfiguration IdentityConfiguration { get; }
    public EmailSmtpConfiguration EmailSmtpConfiguration { get; }
    public ApplicationEnvironmentConfiguration ApplicationEnvironmentConfiguration { get; }

    public ApplicationConfiguration(IConfiguration configuration)
    {
        ApplicationEnvironmentConfiguration = new ApplicationEnvironmentConfiguration(
            Enum.Parse<RunningEnvironment>(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"),
            configuration[WebHostDefaults.ServerUrlsKey] ?? throw new InvalidOperationException());

        DatabaseConfiguration = new DatabaseConfiguration(
            Enum.Parse<DatabaseConfiguration.DatabaseProvider>(configuration["Database:Provider"] ?? throw new InvalidOperationException()),
            configuration["Database:ConnectionString"] ?? throw new InvalidOperationException());
        
        IdentityConfiguration = new IdentityConfiguration()
        {
            Options =
            {
                User = new UserOptions
                {
                    AllowedUserNameCharacters = configuration["Identity:User:AllowedUserNameCharacters"] ?? throw new InvalidOperationException("Identity:User:AllowedUserNameCharacters"),
                    RequireUniqueEmail = bool.Parse(configuration["Identity:User:RequireUniqueEmail"] ?? throw new InvalidOperationException("Identity:User:RequireUniqueEmail"))
                },
                Password = new PasswordOptions
                {
                    RequiredLength = int.Parse(configuration["Identity:Password:RequiredLength"] ?? throw new InvalidOperationException("Identity:Password:RequiredLength")),
                    RequiredUniqueChars = int.Parse(configuration["Identity:Password:RequiredUniqueChars"] ?? throw new InvalidOperationException("Identity:Password:RequiredUniqueChars")),
                    RequireNonAlphanumeric = bool.Parse(configuration["Identity:Password:RequireNonAlphanumeric"] ?? throw new InvalidOperationException("Identity:Password:RequireNonAlphanumeric")),
                    RequireLowercase = bool.Parse(configuration["Identity:Password:RequireLowercase"] ?? throw new InvalidOperationException("Identity:Password:RequireLowercase")),
                    RequireUppercase = bool.Parse(configuration["Identity:Password:RequireUppercase"] ?? throw new InvalidOperationException("Identity:Password:RequireUppercase")),
                    RequireDigit = bool.Parse(configuration["Identity:Password:RequireDigit"] ?? throw new InvalidOperationException("Identity:Password:RequireDigit"))
                },
                SignIn = new SignInOptions
                {
                    RequireConfirmedEmail = bool.Parse(configuration["Identity:SignIn:RequireConfirmedEmail"] ?? throw new InvalidOperationException("Identity:SignIn:RequireConfirmedEmail")),
                    RequireConfirmedPhoneNumber = bool.Parse(configuration["Identity:SignIn:RequireConfirmedPhoneNumber"] ?? throw new InvalidOperationException("Identity:SignIn:RequireConfirmedPhoneNumber")),
                    RequireConfirmedAccount = bool.Parse(configuration["Identity:SignIn:RequireConfirmedAccount"] ?? throw new InvalidOperationException("Identity:SignIn:RequireConfirmedAccount"))
                },
            }
        };

        EmailSmtpConfiguration = new EmailSmtpConfiguration(
            configuration["EmailSmtp:Host"] ?? throw new InvalidOperationException("Email:Smtp:Host"),
            int.Parse(configuration["EmailSmtp:Port"] ?? throw new InvalidOperationException("Email:Smtp:Port")),
            configuration["EmailSmtp:Username"] ?? throw new InvalidOperationException("Email:Smtp:Username"),
            configuration["EmailSmtp:Password"] ?? throw new InvalidOperationException("Email:Smtp:Password"),
            configuration["EmailSmtp:From"] ?? throw new InvalidOperationException("Email:Smtp:From")
        );
    }
}