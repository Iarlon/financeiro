using financeiro.Application.Contract;
using financeiro.Domain.Events;
using financeiro.Domain.Repository;

namespace financeiro.Application.Handles;

public class AtualizarSaldoContaOrcamentoHandler
    : IDomainEventHandler<MovimentacaoCriadaEvent>
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public AtualizarSaldoContaOrcamentoHandler(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task Handle(
        MovimentacaoCriadaEvent domainEvent,
        CancellationToken cancellationToken)
    {
        var orcamento = await _orcamentoRepository.ObterOrcamentoPorId(domainEvent.Movimentacao.OrcamentoId);

        orcamento.AtualizarSaldo(domainEvent.Movimentacao.Valor, domainEvent.Movimentacao.Tipo);

        await _orcamentoRepository.AtualizarOrcamento(orcamento);
    }
}
