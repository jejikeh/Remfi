using Identity.Application.Services;
using Identity.Infrastructure.Common;
using Identity.Infrastructure.Services.Email;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure.Services;

public static class EmailServicesInjection
{
    public static IServiceCollection AddEmailServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailSenderService, EmailSenderService>();
        services.AddScoped<IEmailMessageFactory, EmailMessageFactory>();
        services.AddScoped<SmtpService>();
        
        return services;
    }
}