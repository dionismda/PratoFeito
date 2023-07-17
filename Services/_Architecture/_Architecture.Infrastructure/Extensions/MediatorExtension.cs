using Architecture.Infrastructure.Abstracts;

namespace Architecture.Infrastructure.Extensions;

public static class MediatorExtension
{
    public static async Task DispatchEventsAsync(this IMediator mediator, BaseDbContext context, CancellationToken cancellationToken)
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

        ClearDomainEvents(domainEntities);
    }

    private static async Task DispatchDomainEventsAsync(this IMediator mediator, List<DomainEvent> domainEvents, CancellationToken cancellationToken)
    {
        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }
    }

    private static void ClearDomainEvents(List<AggregateRoot> domainEntities)
    {
        domainEntities.ForEach(domainEntity => domainEntity.ClearDomainEvents());
    }
}
