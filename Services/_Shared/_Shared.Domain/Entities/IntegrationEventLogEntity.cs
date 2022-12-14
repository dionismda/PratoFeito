namespace _Shared.Domain.Entities;

public class IntegrationEventLogEntity : BaseEntity
{
    protected IntegrationEventLogEntity() : base() { }

    public IntegrationEventLogEntity(IIntegrationEvent? integration) : this()
    {
        if (integration is null)
            throw new ArgumentNullException(nameof(integration));

        EventId = integration.Id;
        EventTypeName = integration.GetType().FullName ?? "";
        Content = JsonSerializer.Serialize(integration, integration.GetType(), new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        State = EventStateEnum.NotPublished;
        TimesSent = 0;
        TransactionId = Guid.NewGuid().ToString();
    }

    public Guid EventId { get; private set; }
    public string EventTypeName { get; private set; } = string.Empty;

    [NotMapped]
    public string EventTypeShortName => EventTypeName.Split('.')?.Last() ?? "";
    [NotMapped]
    public IntegrationEvent? IntegrationEvent { get; private set; }

    public EventStateEnum State { get; private set; }
    public int TimesSent { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public string TransactionId { get; private set; } = string.Empty;
    public string Header { get; private set; } = string.Empty;
    public void SetEventState(EventStateEnum state)
    {
        State = state;
    }
    public void SetTimesSent(int timessent)
    {
        TimesSent += timessent;
    }
    public void SetHeader(string header)
    {
        Header = header;
    }
    public IntegrationEventLogEntity DeserializeJsonContent(Type type)
    {
        IntegrationEvent = JsonSerializer.Deserialize(Content, type, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) as IntegrationEvent;
        return this;
    }
}
