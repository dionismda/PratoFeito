namespace EventBusDbContext;

public abstract class IntegrationEventLogContext : DbContext
{
    public string Schema { get; protected set; } = string.Empty;

    protected IntegrationEventLogContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<IntegrationEventLog> IntegrationEventLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        if (Schema != "")
            modelBuilder.HasDefaultSchema(Schema);

        modelBuilder.Entity<IntegrationEventLog>(ConfigureIntegrationEventLogEntry);
    }

    private void ConfigureIntegrationEventLogEntry(EntityTypeBuilder<IntegrationEventLog> builder)
    {
        builder.HasKey(e => e.EventId);

        builder.Property(e => e.EventId)
            .IsRequired();

        builder.Property(e => e.Content)
            .IsRequired();

        builder.Property(e => e.CreationTime)
            .IsRequired();

        builder.Property(e => e.State)
            .IsRequired();

        builder.Property(e => e.TimesSent)
            .IsRequired();

        builder.Property(e => e.EventTypeName)
            .IsRequired();
    }
}
