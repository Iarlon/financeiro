using Dapper;
using financeiro.Domain.Repository;
using financeiro.Infraestructure.Database;
using Financeiro.Domain.Entities;

namespace financeiro.Infraestructure.Repository;

public class OrcamentoRepository : IOrcamentoRepository
{
    private readonly IDbConnectionFactory _connectionFactory;
    public OrcamentoRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    public async Task AtualizarOrcamento(Orcamento orcamento)
    {
        if (orcamento.Id <= 0)
            throw new ArgumentException("Id inválido.", nameof(orcamento.Id));

        var sql = @"
            UPDATE ORCAMENTO
            SET saldo_conta = @Valor
            WHERE ID = @Id
            ";
        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(sql, new {
            orcamento.Id,
            Valor = orcamento.SaldoConta
        });
    }

    public async Task<Orcamento?> ObterOrcamentoPorId(int id)
    {
        var sql = @"SELECT * FROM ORCAMENTO WHERE ID = @Id";

        using var connection = _connectionFactory.CreateConnection();
        var orcamento = await connection.QueryFirstOrDefaultAsync<Orcamento>(sql, new { Id = id });

        return orcamento;
    }
}
