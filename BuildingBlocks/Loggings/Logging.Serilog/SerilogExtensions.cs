namespace Logging.Serilog;

public static class SerilogExtensions
{
    public static List<Tag> AddMetadata(this List<Tag> tags, string key, string value) => tags.Add(key, value);

    private static List<Tag> Add(this List<Tag> tags, string key, object value)
    {
        tags.Add(new Tag(key, value));
        return tags;
    }

    public static void AddSerilogApi()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithCorrelationId()
            .Enrich.WithProperty("PratoFeito", $"API Serilog - {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}")
            .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
            .Filter.ByExcluding(z => z.MessageTemplate.Text.Contains("Business error"))
            .WriteTo.Async(wt => wt.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"))
            .CreateLogger();
    }
}
