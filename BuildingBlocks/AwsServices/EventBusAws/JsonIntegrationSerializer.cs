namespace EventBusAws;

public static class JsonIntegrationSerializer
{
    private static JsonSerializerOptions GetSerializerOptionsDefault()
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
        return JsonSerializer.Serialize(@event, @event.GetType(), new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }

    public static string Serialize(object @object)
    {
        return JsonSerializer.Serialize(@object, @object.GetType(), GetSerializerOptionsDefault());
    }
}