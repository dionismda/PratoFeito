namespace EventBusAws;

public sealed class EventBusLog : SerilogContext
{
    public EventBusLog(string className, string method, Action<List<SerilogTag>>? action = null) : base(action)
    {
        Tags = new List<SerilogTag>()
            .AddMetadata("Class", className)
            .AddMetadata("Method", method);
    }
}