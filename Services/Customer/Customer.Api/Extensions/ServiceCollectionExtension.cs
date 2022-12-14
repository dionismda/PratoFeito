namespace Customer.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection CustomAddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtOptions:SecurityKey").Value));

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configuration.GetSection("JwtOptions:Issuer").Value,

            ValidateAudience = true,
            ValidAudience = configuration.GetSection("JwtOptions:Audience").Value,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = securityKey,

            RequireExpirationTime = true,
            ValidateLifetime = true,

            ClockSkew = TimeSpan.Zero
        };

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = tokenValidationParameters;
        });

        return services;
    }

    public static IServiceCollection CustomAddSwaggerService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RouteOptions>(opt => opt.LowercaseUrls = true);

        services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter your token in the text input below.
                      Example: '12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                }
            });

            opt.UseInlineDefinitionsForEnums();

            opt.ExampleFilters();

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

        services.AddSwaggerExamplesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

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
