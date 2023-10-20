using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}