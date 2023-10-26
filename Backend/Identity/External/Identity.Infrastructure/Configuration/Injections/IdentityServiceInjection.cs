using Identity.Domain.Models;
using Identity.Infrastructure.Configuration;
using Identity.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure.Common.Injections;

public static class IdentityServiceInjection
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IdentityConfiguration identityConfiguration)
    {
        services.AddIdentity<Client, Role>(options =>
            {
                options.User = identityConfiguration.Options.User;
                options.Password = identityConfiguration.Options.Password;
                options.SignIn = identityConfiguration.Options.SignIn;
            })
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders()
            .AddRoles<Role>();
        
        return services;
    }
}