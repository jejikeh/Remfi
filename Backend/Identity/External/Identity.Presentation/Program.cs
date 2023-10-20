using Identity.Presentation.Configuration;

var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureBuilder();

var app = builder
    .Build()
    .ConfigureApplication();

await app.RunApplicationAsync();
