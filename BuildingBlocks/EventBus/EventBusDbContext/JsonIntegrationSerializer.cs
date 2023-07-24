namespace EventBusDbContext;

public static class JsonIntegrationSerializer
{
    public static JsonSerializerOptions GetSerializerOptionsDefault()
    {
        return new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter()
            },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public static string Serialize(IntegrationEvent @event)
    {
        return JsonSerializer.Serialize(@event, @event.GetType(), GetSerializerOptionsDefault());
    }

    public static IntegrationEvent Deserialize(string @event, Type type)
    {
        return (IntegrationEvent)JsonSerializer.Deserialize(@event, type, GetSerializerOptionsDefault())!;
    }
}
