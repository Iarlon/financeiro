using Financeiro.Domain.Exceptions;

namespace Financeiro.Domain.Entities;

public class Orcamento
{
    public int UsuarioId { get; private set; }
    public int Ano { get; private set; }
    public int Mes { get; private set; }
    public decimal ValorMaximo { get; private set; }

    public Orcamento(int usuarioId, int mes, int ano, decimal valorMaximo)
    {
        DefineUsuarioId(usuarioId);
        AlterarMesEAno(mes, ano);
        AlterarValorMaximo(valorMaximo);
    }

    public void AlterarValorMaximo(decimal valorMaximo)
    {
        if (valorMaximo <= 0)
            throw new DomainException("O valor máximo do orçamento deve ser maior que zero.");
        ValorMaximo = valorMaximo;
    }

    public void AlterarMesEAno(int mes, int ano)
    {
        if (mes < 1 || mes > 12)
            throw new DomainException("O mês do orçamento deve estar entre 1 e 12.");
        if (ano < 2000)
            throw new DomainException("O ano do orçamento é inválido.");
        Mes = mes;
        Ano = ano;
    }

    public void DefineUsuarioId(int usuarioId)
    {
        if (usuarioId <= 0)
            throw new DomainException("Não foi encontrado usuário para esse orçamento.");
        UsuarioId = usuarioId;
    }
}
