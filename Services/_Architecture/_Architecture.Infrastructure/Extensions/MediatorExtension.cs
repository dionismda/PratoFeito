namespace _Architecture.Infrastructure.Extensions;

public static class MediatorExtension
{
    public static async Task DispatchEventsAsync(this IMediator mediator, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var domainEntities = context.ChangeTracker
                                    .Entries<AggregateRoot>()
                                    .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
                                    .Select(e => e.Entity)
                                    .ToList();

        var domainEvents = domainEntities
                           .SelectMany(x => x.DomainEvents!)
                           .ToList();

        await mediator.DispatchDomainEventsAsync(domainEvents, cancellationToken);

        await DispatchIntegrationEventsAsync(domainEvents, context, cancellationToken);

        ClearDomainEvents(domainEntities);
    }

    private static async Task DispatchDomainEventsAsync(this IMediator mediator, List<DomainEvent> domainEvents, CancellationToken cancellationToken)
    {
        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }
    }

    private static async Task DispatchIntegrationEventsAsync(IEnumerable<DomainEvent> domainEvents, ApplicationDbContext logContext, CancellationToken cancellationToken)
    {
        var integrationEvents = logContext.EventLogContext?.EventMapper.Map(domainEvents);

        if (integrationEvents != null)
        {
            await logContext.EventLogContext.IntegrationEventLogs.AddRangeAsync(integrationEvents, cancellationToken);

            await logContext.EventLogContext.SaveChangesAsync(cancellationToken);
        }
    }

    private static void ClearDomainEvents(List<AggregateRoot> domainEntities)
    {
        domainEntities.ForEach(domainEntity => domainEntity.ClearDomainEvents());
    }
}
