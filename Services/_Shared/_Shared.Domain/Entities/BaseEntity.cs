namespace _Shared.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }

    private List<DomainEvent> _domainEvents = new();

    [JsonIgnore] 
    public IReadOnlyCollection<DomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public void AddDomainEvent(DomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(DomainEvent eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}
