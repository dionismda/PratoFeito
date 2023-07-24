namespace _Architecture.Infrastructure.Abstractions;

public abstract class BaseDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public string Schema { get; protected set; } = string.Empty;

    protected BaseDbContext(
        DbContextOptions options,
        IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension("uuid-ossp");

        if (Schema != "")
            modelBuilder.HasDefaultSchema(Schema);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("PratoFeitoDb");

        optionsBuilder
            .UseNpgsql(connectionString, x =>
            {
                x.MigrationsHistoryTable("__EFMigrationsHistory", Schema);
                x.MigrationsAssembly("Monolith");
            })
            .UseSnakeCaseNamingConvention()
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
}
