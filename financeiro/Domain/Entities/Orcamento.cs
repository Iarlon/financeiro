using Financeiro.Domain.Enums;
using Financeiro.Domain.Exceptions;

namespace Financeiro.Domain.Entities;

public class Orcamento
{
    public long Id { get; private set; }
    public int UsuarioId { get; private set; }
    public DateTime Periodo { get; private set; }
    public decimal SaldoConta { get; private set; } = decimal.Zero;

    public Orcamento(int usuarioId, DateTime periodo)
    {
        DefineUsuarioId(usuarioId);
        AlterarPeriodo(periodo);
   
    }

    public void AlterarPeriodo(DateTime dataReferencia)
    {
        if (dataReferencia.Year < 2000)
            throw new DomainException("O ano do orçamento é inválido.");
        Periodo = new DateTime(dataReferencia.Year, dataReferencia.Month, 1);
    }

    public void DefineUsuarioId(int usuarioId)
    {
        if (usuarioId <= 0)
            throw new DomainException("Não foi encontrado usuário para esse orçamento.");
        UsuarioId = usuarioId;
    }

    public void AtualizarSaldo(decimal valor, TipoMovimentacaoEnum tipo)
    {
        if (tipo == TipoMovimentacaoEnum.despesa)
            SaldoConta -= valor;
        else
            SaldoConta += valor;
    }
}
