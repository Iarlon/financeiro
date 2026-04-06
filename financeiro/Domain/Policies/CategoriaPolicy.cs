using Financeiro.Domain.Enums;

namespace Financeiro.Domain.Policies;

internal static class CategoriaPolicy
{
    public static TipoMovimentacao TipoDaCategoria(Categoria categoria)
    {
        return categoria switch
        {
            Categoria.Alimentacao or
            Categoria.Moradia or
            Categoria.Transporte or
            Categoria.Lazer or
            Categoria.Saude or 
            Categoria.Educacao or 
            Categoria.Investimentos
                => TipoMovimentacao.despesa,

            Categoria.Salario or
            Categoria.Bonus or
            Categoria.Freelance or
            Categoria.HoraExtra or
            Categoria.Freelance or 
            Categoria.Comissao or
            Categoria.Transferencias or
            Categoria.Vendas or
            Categoria.Servicos
                => TipoMovimentacao.receita,

            _ => throw new ArgumentOutOfRangeException(nameof(categoria))
        };
    }

    public static bool CategoriaEhCompativel(
        Categoria categoria,
        TipoMovimentacao tipo)
        => TipoDaCategoria(categoria) == tipo;
}
