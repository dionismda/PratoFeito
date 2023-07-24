namespace EventBusDbContext;

public class IntegrationEventLog
{
    public Guid EventId { get; }
    public string EventTypeName { get; } = string.Empty;

    [NotMapped]
    public string EventTypeShortName => EventTypeName.Split('.').Last();
    [NotMapped]
    public IntegrationEvent? IntegrationEvent { get; private set; }

    public EventStateEnum State { get; private set; }
    public int TimesSent { get; private set; }
    public string Content { get; } = string.Empty;
    public string TransactionId { get; } = string.Empty;
    public DateTime CreationTime { get; private set; }

    public IntegrationEventLog(IntegrationEvent? integration)
    {
        if (integration is null)
            throw new ArgumentNullException(nameof(integration));

        EventId = integration.Id;
        EventTypeName = integration.GetType().FullName ?? "";
        Content = JsonIntegrationSerializer.Serialize(integration);
        State = EventStateEnum.NotPublished;
        TimesSent = 0;
        TransactionId = Guid.NewGuid().ToString();
        CreationTime = integration.CreationDate;
    }

    public void ChangeStatus(EventStateEnum state)
    {
        State = state;
    }

    public void IncrementTimesSent()
    {
        TimesSent++;
    }

    public IntegrationEventLog DeserializeJsonContent(Type type)
    {
        IntegrationEvent = JsonIntegrationSerializer.Deserialize(Content, type);
        return this;
    }
}
