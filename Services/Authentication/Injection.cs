public static class Injection
{
    public static IServiceCollection InjectAuthentication(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AuthenticationDbContext>();

        services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>()
                .AddUserManager<UserManager<IdentityUser<Guid>>>()
                .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
                .AddEntityFrameworkStores<AuthenticationDbContext>()
                .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(opt =>
        {
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            opt.Lockout.MaxFailedAccessAttempts = 5;
            opt.Lockout.AllowedForNewUsers = true;

            opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        });

        var defaultSetting = configuration.GetSection(nameof(DefaultSetting));
        services.Configure<DefaultSetting>(options =>
        {
            options.DefaultSecretKey = defaultSetting[nameof(DefaultSetting.DefaultSecretKey)];
        });

        var cryptographySetting = configuration.GetSection(nameof(CryptographySetting));
        services.Configure<CryptographySetting>(options =>
        {
            options.SecretKey = cryptographySetting[nameof(CryptographySetting.SecretKey)];
            options.EncryptionKey = cryptographySetting[nameof(CryptographySetting.EncryptionKey)];
        });

        var dataBaseSetting = configuration.GetSection(nameof(DataBaseSetting));
        services.Configure<DataBaseSetting>(options =>
        {
            options.DefaultServer = dataBaseSetting[nameof(DataBaseSetting.DefaultServer)];
            options.DefaultPort = dataBaseSetting[nameof(DataBaseSetting.DefaultPort)];
            options.DefaultDatabase = dataBaseSetting[nameof(DataBaseSetting.DefaultDatabase)];
            options.DefaultDatabaseUser = dataBaseSetting[nameof(DataBaseSetting.DefaultDatabaseUser)];
            options.DefaultDatabasePass = dataBaseSetting[nameof(DataBaseSetting.DefaultDatabasePass)];
        });

        var jwtOptions = configuration.GetSection(nameof(JwtOptions));
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtOptions:SecurityKey").Value));

        services.Configure<JwtOptions>(options =>
        {
            options.Issuer = jwtOptions[nameof(JwtOptions.Issuer)];
            options.Audience = jwtOptions[nameof(JwtOptions.Audience)];
            options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            options.AccessTokenExpiration = int.Parse(jwtOptions[nameof(JwtOptions.AccessTokenExpiration)] ?? "0");
        });

        services.AddScoped<ICipherCryptographyService, CipherCryptographyService>();

        services
            .CustomAddAuthentication(configuration)
            .CustomAddSwaggerService(configuration)
            .CustomAddVersioningService();

        return services;
    }

}