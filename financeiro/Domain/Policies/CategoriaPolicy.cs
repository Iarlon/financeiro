using Financeiro.Domain.Enums;

namespace Financeiro.Domain.Policies;

internal static class CategoriaPolicy
{
    private static readonly HashSet<CategoriaEnum> CategoriasDespesa =
    [
        CategoriaEnum.Alimentacao,
        CategoriaEnum.Moradia,
        CategoriaEnum.Transporte,
        CategoriaEnum.Lazer,
        CategoriaEnum.Saude,
        CategoriaEnum.Educacao,
        CategoriaEnum.Investimentos
    ];

    private static readonly HashSet<CategoriaEnum> CategoriasReceita =
    [
        CategoriaEnum.Salario,
        CategoriaEnum.Bonus,
        CategoriaEnum.Freelance,
        CategoriaEnum.HoraExtra,
        CategoriaEnum.Comissao,
        CategoriaEnum.Transferencias,
        CategoriaEnum.Vendas,
        CategoriaEnum.Servicos
    ];

    public static TipoMovimentacaoEnum TipoDaCategoria(CategoriaEnum categoria)
    {
        if (CategoriasDespesa.Contains(categoria))
            return TipoMovimentacaoEnum.despesa;

        if (CategoriasReceita.Contains(categoria))
            return TipoMovimentacaoEnum.receita;

        throw new ArgumentOutOfRangeException(nameof(categoria));
    }

    public static bool CategoriaEhCompativel(CategoriaEnum categoria, TipoMovimentacaoEnum tipo)
        => TipoDaCategoria(categoria) == tipo;
}
