﻿namespace _Architecture.Infrastructure.Abstractions;

public abstract class AggregateTypeMap<TAggregate> : EntityTypeMap<TAggregate>
    where TAggregate : AggregateRoot
{
    public override void Configure(EntityTypeBuilder<TAggregate> builder)
    {
        base.Configure(builder);

        builder
            .Ignore(e => e.DomainEvents);
    }
}
