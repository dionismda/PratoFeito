using MassTransit;

namespace _Architecture.Infrastructure.MassTransit;

public class CustomFormatter : IEndpointNameFormatter, IEntityNameFormatter
{
    private readonly IEndpointNameFormatter _defaultFormatter;
    public string Separator { get; } = string.Empty;

    public CustomFormatter(IEndpointNameFormatter defaultFormatter)
    {
        _defaultFormatter = defaultFormatter;
    }

    public string TemporaryEndpoint(string tag)
    {
        return _defaultFormatter.TemporaryEndpoint(tag);
    }

    public string Consumer<T>()
        where T : class, IConsumer
    {
        var defaultName = _defaultFormatter.Consumer<T>();
        // Please give this a bit more thought. This is just to make a point.
        var type = typeof(T).GetInterfaces().First().GenericTypeArguments.First();

        if (type.Namespace.Contains("command", StringComparison.OrdinalIgnoreCase))
        {
            return defaultName + ".fifo";
        }

        return defaultName;
    }

    public string FormatEntityName<T>()
    {
        var type = typeof(T);

        if (type.Namespace.Contains("command", StringComparison.OrdinalIgnoreCase))
        {
            return type.Name + ".fifo";
        }

        return type.Name;
    }

    public string Message<T>()
        where T : class
    {
        return _defaultFormatter.Message<T>();
    }

    public string Saga<T>()
        where T : class, ISaga
    {
        return _defaultFormatter.Saga<T>();
    }

    public string ExecuteActivity<T, TArguments>()
        where T : class, IExecuteActivity<TArguments>
        where TArguments : class
    {
        return _defaultFormatter.ExecuteActivity<T, TArguments>();
    }

    public string CompensateActivity<T, TLog>()
        where T : class, ICompensateActivity<TLog>
        where TLog : class
    {
        return _defaultFormatter.CompensateActivity<T, TLog>();
    }

    public string SanitizeName(string name)
    {
        return name;
    }
}