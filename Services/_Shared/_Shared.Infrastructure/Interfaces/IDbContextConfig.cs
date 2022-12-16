namespace _Shared.Infrastructure.Interfaces;

public interface IDbContextConfig
{
    Guid TenantId { get; }
    string Server { get; }
    string Port { get; }
    string DbAlias { get; }
    string DbUser { get; }
    string DbPass { get; }

    public void SetConfig(string server, string port, string dbAlias, string dbUser, string dbPass, Guid tenantId);
}
