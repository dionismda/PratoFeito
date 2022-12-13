namespace _Shared.Domain.Entities;

public class ConsumerEventLogEntity : BaseEntity
{
    public Guid EventId { get; private set; }
    public string Name { get; private set; }
    public DateTime Time { get; private set; }

    protected ConsumerEventLogEntity() : base() { }

    public ConsumerEventLogEntity(Guid eventId, string name) : this()
    {
        EventId = eventId;
        Name = name;
        Time = DateTime.UtcNow;
    }
}
