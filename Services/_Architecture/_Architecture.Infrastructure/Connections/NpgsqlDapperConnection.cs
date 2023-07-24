namespace _Architecture.Infrastructure.Connections;

public sealed class NpgsqlDapperConnection : IConnectionDapper
{
    private readonly IConfiguration _configuration;

    public NpgsqlDapperConnection(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IDbConnection> GetConnectionAsync(string? schema = null)
    {
        var connectionString = _configuration.GetConnectionString("PratoFeitoDb") ?? throw new NullReferenceException("connectionString");

        if (schema is not null)
            connectionString += $"SearchPath={schema}";

        var connection = new NpgsqlConnection(connectionString);

        await connection.OpenAsync();

        return connection;
    }
}
