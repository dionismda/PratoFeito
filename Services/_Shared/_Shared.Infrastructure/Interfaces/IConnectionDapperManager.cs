namespace _Shared.Infrastructure.Interfaces;

public interface IConnectionDapperManager
{
    Task<IDbConnection> GetConnectionAsync();
}
