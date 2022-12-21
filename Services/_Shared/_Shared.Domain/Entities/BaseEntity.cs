namespace _Shared.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public Guid TenantId { get; set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? Updateddate { get; private set; }

    private List<DomainEvent> _domainEvents = new();

    [JsonIgnore] 
    public IReadOnlyCollection<DomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow.ToUniversalTime();
        Updateddate = null;
    }

    public void ModifyUpdatedDate()
    {
        Updateddate = DateTime.UtcNow.ToUniversalTime();
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
