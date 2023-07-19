namespace _Architecture.Api.Middlewares;

public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.StackTrace);

            switch (ex)
            {
                case DomainWarningException exception:
                    await context.ResponseWarning(exception.Message, exception.Errors);
                    break;

                default:
                    await context.ResponseError(ex.Message);
                    break;
            }
        }
    }
}
