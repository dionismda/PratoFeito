namespace Architecture.Infrastructure.Interfaces;

public interface IConnectionDapper
{
    Task<IDbConnection> GetConnectionAsync();
}
