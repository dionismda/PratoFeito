namespace Authentication.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection CustomAddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication()
            .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKey", null); ;

        return services;
    }

    public static IServiceCollection CustomAddSwaggerService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RouteOptions>(opt => opt.LowercaseUrls = true);

        services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Description = "ApiKey must appear in header",
                Name = "XApiKey",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "ApiKeyScheme"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
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

            opt.UseInlineDefinitionsForEnums();

            var swaggerOptions = new SwaggerOptions();
            configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            foreach (var currentVersion in swaggerOptions.Versions)
            {
                opt.SwaggerDoc(currentVersion.Name, new OpenApiInfo()
                {
                    Title = swaggerOptions.Title,
                    Version = currentVersion.Name,
                    Description = swaggerOptions.Description
                });
            }

            opt.DocInclusionPredicate((version, desc) =>
            {
                if (!desc.TryGetMethodInfo(out MethodInfo methodInfo))
                    return false;

                if (methodInfo.DeclaringType is null)
                    return false;

                var versions = methodInfo.DeclaringType.GetConstructors()
                    .SelectMany(constructorInfo => constructorInfo.DeclaringType!.CustomAttributes
                        .Where(attributeData => attributeData.AttributeType == typeof(ApiVersionAttribute))
                        .SelectMany(attributeData => attributeData.ConstructorArguments
                            .Select(attributeTypedArgument => attributeTypedArgument.Value)));

                return versions.Any(v => $"{v}" == version);
            });

        });

        return services;
    }

    public static IServiceCollection CustomAddVersioningService(this IServiceCollection services)
    {
        services.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.ReportApiVersions = true;
            setup.ApiVersionReader = new UrlSegmentApiVersionReader();
        });

        services.AddVersionedApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        services.AddApiVersioning(apiVersioningOptions =>
        {
            apiVersioningOptions.ReportApiVersions = true;
            apiVersioningOptions.ApiVersionReader = new UrlSegmentApiVersionReader();
        });

        return services;
    }

}
