using Financeiro.Domain.Entities;
using Financeiro.Domain.Enums;

namespace financeiro.Domain.Repository;

public interface IOrcamentoRepository
{
    Task<Orcamento> ObterOrcamentoPorId(int id);
    Task AtualizarOrcamento(Orcamento orcamento);
}
