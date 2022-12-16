namespace _Shared.Infrastructure.ContextConnetions;

public class DbContextConfig : IDbContextConfig
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public Guid TenantId { get; private set; }

    public string Server { get; private set; } = string.Empty;

    public string Port { get; private set; } = string.Empty;

    public string DbAlias { get; private set; } = string.Empty;

    public string DbUser { get; private set; } = string.Empty;

    public string DbPass { get; private set; } = string.Empty;

    public void SetConfig(string server, string port, string dbAlias, string dbUser, string dbPass, Guid tenantId)
    {
        TenantId = tenantId;
        Server = server;
        DbAlias = dbAlias;
        DbUser = dbUser;
        DbPass = dbPass;
    }
}
