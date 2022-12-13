namespace _Shared.Infrastructure.Extensions.Mediators;

public static class MediatrExtension
{
    public static async Task DispatchEventsAsync(this IDomainMediator mediator, BaseContext context)
    {
        var domainEntities = context.ChangeTracker
            .Entries<BaseEntity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.DomainEvents!)
            .ToList();

        await mediator.DispatchDomainEventsAsync(domainEvents);
        await DispatchIntegrationEventsAsync(domainEvents, context);

        ClearDomainEvents(domainEntities);
    }

    private static async Task DispatchDomainEventsAsync(this IDomainMediator mediator, List<DomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }

    private static async Task DispatchIntegrationEventsAsync(IEnumerable<DomainEvent> domainEvents, BaseContext context)
    {
        var integrationEvents = context.EventMapper.Map(domainEvents);

        if (integrationEvents != null)
        {
            await context.IntegrationEventLog.AddRangeAsync(integrationEvents);
        }
    }

    private static void ClearDomainEvents(List<BaseEntity> domainEntities)
    {
        domainEntities.ForEach(domainEntity => domainEntity.ClearDomainEvents());
    }

}