using Dapper;
using financeiro.Domain.Repository;
using financeiro.Infraestructure.Database;
using Financeiro.Domain.Entities;

namespace financeiro.Infraestructure.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public UsuarioRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task CriarUsuario(Usuario usuario)
    {
        var sql = @"
            insert into usuario (nome, email, senha)
            values (@Nome, @Email, @Senha)";

        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(sql, usuario);
    }

    public async Task<bool> EmailJaExiste(string email)
    {
        var sql = @"
        SELECT EXISTS (
            SELECT 1 FROM Usuario WHERE Email = @Email
        )";

        using var connection = _connectionFactory.CreateConnection();

        var existe = await connection.ExecuteScalarAsync<bool>(
        sql,
        new { Email = email }
    );

        return existe;
    }

    public async Task AtualizarUsuario(Usuario usuario)
    {
        var sql = @"
        UPDATE USUARIO
        SET NOME = @Nome,
            EMAIL = @Email
        WHERE id = @Id
        ";

        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(sql, usuario);
    }

    public async Task<Usuario?> ObterUsuarioPorId(int id)
    {
        var sql = @"SELECT * FROM USUARIO WHERE ID = @Id";

        using var connection = _connectionFactory.CreateConnection();
        var usuario = await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });

        return usuario;
    }
}
