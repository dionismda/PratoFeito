using Microsoft.OpenApi.Models;
using Monolith.Settings;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Monolith.Extensions;

public static class SwaggerExtension
{

    public static IServiceCollection CustomAddSwaggerService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter your token in the text input below.
                      Example: '12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Description = "ApiKey must appear in header",
                Name = "XApiKey",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "ApiKeyScheme"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                },
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        },
                        Name = "XApiKey",
                        Scheme = "ApiKeyScheme",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });

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

            options.UseInlineDefinitionsForEnums();
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

            option.DocExpansion(DocExpansion.List);
        });

        return app;
    }
}
