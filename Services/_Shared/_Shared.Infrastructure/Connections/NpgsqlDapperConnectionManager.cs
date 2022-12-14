namespace _Shared.Infrastructure.Connections;

public class NpgsqlDapperConnectionManager : IConnectionDapperManager
{
    protected readonly DataBaseSetting DataBaseSettings;

    public NpgsqlDapperConnectionManager(IOptions<DataBaseSetting> dataBaseSettings)
    {
        DataBaseSettings = dataBaseSettings.Value;
    }

    public async Task<IDbConnection> GetConnectionAsync()
    {
        var connectionString =
            $"Server={DataBaseSettings.DefaultServer};Port=5432;Database={DataBaseSettings.DefaultDatabase};User Id={DataBaseSettings.DefaultDatabaseUser};Password={DataBaseSettings.DefaultDatabasePass};";

        var connection = new NpgsqlConnection(connectionString);

        await connection.OpenAsync();

        return connection;
    }
}
