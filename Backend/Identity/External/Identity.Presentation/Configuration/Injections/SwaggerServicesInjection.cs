namespace Identity.Presentation.Configuration.Injections;

public static class SwaggerServicesInjection
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        return services.AddSwaggerGen();
    }
}