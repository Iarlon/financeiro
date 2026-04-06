using System.Data;

namespace financeiro.Infraestructure.Database;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
