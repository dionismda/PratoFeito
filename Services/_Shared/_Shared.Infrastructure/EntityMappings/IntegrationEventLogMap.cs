namespace _Shared.Infrastructure.EntityMappings;

public class IntegrationEventLogMap : BaseEntityMap<IntegrationEventLogEntity>
{
    public override void Configure(EntityTypeBuilder<IntegrationEventLogEntity> builder)
    {
        builder.Property(e => e.EventId)
            .IsRequired();

        builder.Property(e => e.Content)
            .IsRequired();

        builder.Property(e => e.State)
            .IsRequired();

        builder.Property(e => e.TimesSent)
            .IsRequired();

        builder.Property(e => e.EventTypeName)
            .IsRequired();

        builder.Property(e => e.Header)
            .IsRequired();

        base.Configure(builder);
    }
}
