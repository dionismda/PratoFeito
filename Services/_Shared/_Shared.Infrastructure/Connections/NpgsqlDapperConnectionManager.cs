namespace _Shared.Infrastructure.Connections;

public class NpgsqlDapperConnectionManager : IConnectionDapperManager
{
    private readonly DataBaseSetting _dataBaseSettings;

    public NpgsqlDapperConnectionManager(IOptions<DataBaseSetting> dataBaseSettings)
    {
        _dataBaseSettings = dataBaseSettings.Value;
    }

    public async Task<IDbConnection> GetConnectionAsync()
    {
        var connectionString =
            $"Server={_dataBaseSettings.DefaultServer};Port={_dataBaseSettings.DefaultPort};Database={_dataBaseSettings.DefaultDatabase};User Id={_dataBaseSettings.DefaultDatabaseUser};Password={_dataBaseSettings.DefaultDatabasePass};";

        var connection = new NpgsqlConnection(connectionString);

        await connection.OpenAsync();

        return connection;
    }
}
