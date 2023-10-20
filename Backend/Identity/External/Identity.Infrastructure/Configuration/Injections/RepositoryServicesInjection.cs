using Identity.Application.Services;
using Identity.Domain.Models;
using Identity.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure.Common.Injections;

public static class RepositoryServicesInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IClientManager, ClientManager>();
    }
}