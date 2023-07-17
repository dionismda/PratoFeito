namespace Monolith.Extensions;

public static class SwaggerExtension
{
    public static IServiceCollection CustomAddSwaggerService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            var swaggerSettings = new SwaggerSettings();
            configuration.GetSection("Swagger").Bind(swaggerSettings);

            foreach (var msName in swaggerSettings.Microservices.Select(e => e.Name))
            {
                options.SwaggerDoc(msName, new OpenApiInfo
                {
                    Title = swaggerSettings.Title,
                    Version = msName,
                    Description = swaggerSettings.Description
                });
            }

        });

        return services;
    }

    public static IApplicationBuilder CustomConfigureSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
        var swaggerSettings = new SwaggerSettings();
        configuration.GetSection("Swagger").Bind(swaggerSettings);

        app.UseSwagger(option => option.RouteTemplate = swaggerSettings.JsonRoute);

        app.UseSwaggerUI(option =>
        {
            foreach (var msName in swaggerSettings.Microservices.Select(e => e.Name))
            {
                option.SwaggerEndpoint($"/swagger/{msName}/swagger.json", $"{swaggerSettings.Title} {msName}");
            }
        });

        return app;
    }
}
