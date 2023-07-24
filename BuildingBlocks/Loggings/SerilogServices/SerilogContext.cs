namespace SerilogServices;

public abstract class SerilogContext : IDisposable
{
    protected IDisposable? SerilogLogContext { get; private set; }
    protected List<Tag> Tags { get; set; } = new();

    private readonly Action<List<Tag>>? _action;

    private volatile bool _disposedValue;

    protected SerilogContext(Action<List<Tag>>? action = null)
    {
        _action = action;
    }

    public virtual SerilogContext CreateLog()
    {
        _action?.Invoke(Tags);

        SerilogLogContext = LogContext.Push(Tags.Select(it => new PropertyEnricher(it.Key, it.Value, true)).ToArray());

        return this;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue) return;

        if (disposing)
            SerilogLogContext?.Dispose();

        _disposedValue = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}