namespace _Architecture.Api.Extensions;

public static class HttpContextExtension
{
    private static string JsonResponseSerializer(IResponse response)
    {
        return JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter()
            },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }

    public static Task ResponseError(this HttpContext context, string message, object? error = null)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = MediaTypeNames.Application.Json;
        return context.Response.WriteAsync(JsonResponseSerializer(new ResponseError(message, error)));
    }

    public static Task ResponseWarning<TObject>(this HttpContext context, string message, TObject error)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = MediaTypeNames.Application.Json;

        return context.Response.WriteAsync(JsonResponseSerializer(new ResponseWarning<TObject>(message, error)));
    }
}
