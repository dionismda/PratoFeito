namespace _Shared.Infrastructure.EntityMappings;

public class ConsumerEventLogEntityMap : BaseEntityMap<ConsumerEventLogEntity>
{
    public override void Configure(EntityTypeBuilder<ConsumerEventLogEntity> builder)
    {        
        builder.Property(cel => cel.EventId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(cel => cel.Name)
                .IsRequired();

        builder.Property(cel => cel.DateConsumed)
                .IsRequired();

        base.Configure(builder);
    }
}
