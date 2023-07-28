namespace Logging.Serilog;

public class Tag
{
    public string Key { get; private set; } = string.Empty;
    public object? Value { get; private set; }

    public Tag()
    {
    }

    public Tag(string key, object? value = default)
    {
        Key = key;
        Value = value;
    }
}
