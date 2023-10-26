using Identity.Application;
using Identity.Infrastructure;
using Identity.Infrastructure.Common;
using Identity.Infrastructure.Configuration;
using Identity.Infrastructure.Persistence;
using Identity.Presentation.Configuration.Injections;

namespace Identity.Presentation.Configuration;

public static class ApplicationConfigurator
{
    public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
    {
        var applicationConfiguration = new ApplicationConfiguration(builder.Configuration);

        builder.Services
            .AddSingleton<IApplicationConfiguration>(applicationConfiguration)
            .AddApplication()
            .AddInfrastructure(applicationConfiguration)
            .AddControllers();

        builder.Services
            .AddSwagger()
            .AddEndpointsApiExplorer();
        
        return builder;
    }
    
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.MapControllers();
        app.UseHttpsRedirection();
        
        // TODO: Depend on the environment
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    public static async Task<WebApplication> RunApplicationAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        
        try
        {
            var versityUsersDbContext = serviceProvider.GetRequiredService<IdentityContext>();
            await versityUsersDbContext.Database.EnsureCreatedAsync();
            
            await app.RunAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR:" + ex.Message);
            
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Host terminated unexpectedly");
        }

        return app;
    }
}