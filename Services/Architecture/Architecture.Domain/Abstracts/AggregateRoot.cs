namespace Architecture.Domain.Abstracts;

public abstract class AggregateRoot : Entity
{
    private List<DomainEvent> _domainEvents;
    public IReadOnlyCollection<DomainEvent> DomainEvents
    {
        get => _domainEvents.AsReadOnly();
        private set => _domainEvents = value.ToList();
    }

    public IEnumerable<DomainEvent> GetUncommittedChanges() => _domainEvents;

    protected AggregateRoot() : base()
    {
        _domainEvents = new List<DomainEvent>();
    }

    private void ApplyDomainEventChange(DomainEvent @event)
    {
        var method = GetType().GetMethod("Apply", new Type[] { @event.GetType() });

        if (method == null)
            throw new ArgumentNullException($"The Apply method was not found in the aggregate for {@event.GetType().Name}!");

        method.Invoke(this, new object[] { @event });
    }

    public void AddDomainEvent(DomainEvent eventItem)
    {
        ApplyDomainEventChange(eventItem);
        _domainEvents.Add(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
