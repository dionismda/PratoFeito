namespace _Shared.Api.Extensions;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder CustomConfigureSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
        var swaggerOptions = new SwaggerOptions();
        configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

        app.UseSwagger(opt => opt.RouteTemplate = swaggerOptions.JsonRoute);
        app.UseSwaggerUI(opt =>
        {
            foreach (var currentVersion in swaggerOptions.Versions)
            {
                opt.SwaggerEndpoint(currentVersion.UriEndpoint, $"{swaggerOptions.Title} {currentVersion.Name}");
            }

            opt.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
        });

        return app;
    }
}
