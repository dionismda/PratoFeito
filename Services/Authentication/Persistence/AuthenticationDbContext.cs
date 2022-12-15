namespace Authentication.Persistence;

public class AuthenticationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    private readonly DataBaseSetting _dataBaseSettings;

    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options,
                                   IOptions<DataBaseSetting> dataBaseSetting) : base(options)
    {
        _dataBaseSettings = dataBaseSetting.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            $"Server={_dataBaseSettings.DefaultServer};Port={_dataBaseSettings.DefaultPort};Database={_dataBaseSettings.DefaultDatabase};User Id={_dataBaseSettings.DefaultDatabaseUser};Password={_dataBaseSettings.DefaultDatabasePass};";

        optionsBuilder
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<IdentityUser<Guid>>().ToTable("user");
        modelBuilder.Entity<IdentityRole<Guid>>().ToTable("role");
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claim");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_role");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claim");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_login");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_token");
    }

}
