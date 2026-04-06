using financeiro.Infraestructure.Database;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

public class NpgsqlConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _configuration;

    public NpgsqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(
            _configuration.GetConnectionString("Default"));
    }
}