namespace _Architecture.Infrastructure.Abstractions;

public abstract class DapperQueries
{
    protected IConnectionDapper ConnectionDapper { get; private set; }

    protected DapperQueries(IConnectionDapper connectionDapper)
    {
        ConnectionDapper = connectionDapper;
    }
}
