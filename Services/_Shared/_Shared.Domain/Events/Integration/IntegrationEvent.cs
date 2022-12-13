namespace _Shared.Domain.Events.Integration;

public abstract class IntegrationEvent : IIntegrationEvent
{
    [JsonInclude]
    public Guid Id { get; private init; }
    [JsonInclude]
    public DateTime CreatedAt { get; private init; }
    [JsonIgnore]
    public string IntegrationTypeName => GetType().Name;
    public IntegrationEvent()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public IntegrationEvent(Guid id, DateTime createDate)
    {
        Id = id;
        CreatedAt = createDate;
    }
}
