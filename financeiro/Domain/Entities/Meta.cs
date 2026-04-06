using Financeiro.Domain.Enums;
using Financeiro.Domain.Exceptions;

namespace Financeiro.Domain.Entities;

public class Meta
{
    public long Id { get; private set; }
    public decimal ValorObjetivo { get; private set; }
    public DateTime DataFinal { get; private set; }
    public decimal ValorAporte { get; private set; }
    public PeriodicidadeAporte Periodicidade { get; private set; }
    public string Descricao { get; set; }
    public int UsuarioId { get; private set; }
    public StatusAtual Status { get; private set; }

    public Meta(
        decimal valorObjetivo,
        DateTime dataFinal,
        PeriodicidadeAporte periodicidade,
        string descricao,
        int usuario) {
        AlterarValorFinal(valorObjetivo);
        AlterarDescricao(descricao);
        AlterarDataFinal(dataFinal);
        AlterarPeriodicidade(periodicidade);

        DefinirUsuarioId(usuario);
        DefinirStatusInicial();
        DefineInitialAporte();
    }

    public void AlterarValorFinal(decimal valorObjetivo) {
        if (valorObjetivo <= 0)
            throw new Domain.Exceptions.DomainException("O valor objetivo da meta deve ser maior que zero.");
        ValorObjetivo = valorObjetivo;
    }

    public void AlterarDataFinal(DateTime dataFinal)
    {
        if (dataFinal <= DateTime.UtcNow)
            throw new Domain.Exceptions.DomainException("A data final da meta deve ser uma data futura.");
        DataFinal = dataFinal;
    }

    public void AlterarDescricao(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new Domain.Exceptions.DomainException("A descrição da meta não pode ser vazia.");
        Descricao = descricao.Trim();
    }

    private void DefinirUsuarioId(int usuarioId)
    {
        if (usuarioId <= 0)
            throw new Domain.Exceptions.DomainException("Não foi encontrado usuário para essa meta.");
        UsuarioId = usuarioId;
    }
    public void AlterarPeriodicidade(PeriodicidadeAporte periodicidade)
    {
        if (!Enum.IsDefined(typeof(PeriodicidadeAporte), periodicidade))
            throw new DomainException("Periodicidade inválida.");

        Periodicidade = periodicidade;
    }
    private void DefinirStatusInicial()
    {
        Status = StatusAtual.NaMeta;
    }

    public void AtualizarStatusAtual(StatusAtual status)
    {
        if (!Enum.IsDefined(typeof(StatusAtual), status))
            throw new DomainException("Status inválido.");
        Status = status;
    }

    public void RegistrarAporte(decimal valorAporte)
    {
        if (valorAporte < 0)
            throw new DomainException("O valor do aporte não pode ser negativo.");
        ValorAporte = valorAporte;
    }

    private void DefineInitialAporte()
    {
        ValorAporte = 0;
    }
}
