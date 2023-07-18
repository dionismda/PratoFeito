namespace _Architecture.Infrastructure.Connetions;

public sealed class NpgsqlDapperConnection : IConnectionDapper
{
    private readonly IConfiguration _configuration;

    public NpgsqlDapperConnection(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IDbConnection> GetConnectionAsync()
    {
        var connection = new NpgsqlConnection(_configuration.GetConnectionString("MicroserviceDb"));

        await connection.OpenAsync();

        return connection;
    }
}
