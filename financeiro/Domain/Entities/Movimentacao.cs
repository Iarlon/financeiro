using Financeiro.Domain.Enums;
using Financeiro.Domain.Exceptions;
using Financeiro.Domain.Policies;

namespace Financeiro.Domain.Entities;

public class Movimentacao
{
    public long Id { get; private set; }
    public int UsuarioId { get; private set; }
    public string? Tag { get; private set; }
    public string? Descricao { get; private set; }
    public decimal Valor { get; private set; }
    public Categoria Categoria { get; private set; }
    public DateTime Data { get; private set; }
    public TipoMovimentacao Tipo { get; private set; }

    public Movimentacao(
        decimal valor,
        Categoria categoria,
        int usuarioId,
        TipoMovimentacao tipo
        )
    {
        AlterarTipo(tipo);
        AlterarCategoria(categoria);
        AlterarValor(valor);
        DefinirUsuarioId(usuarioId);
    }
    public void AlterarTag(string tag)
    {
        Tag = tag?.Trim();
    }

    public void AlterarDescricao(string descricao)
    {
        Descricao = descricao?.Trim();
    }

    private void AlterarValor(decimal valor)
    {
        if (valor <= 0)
            throw new DomainException("O valor deve ser maior que zero.");
        Valor = valor;
    }

    public void AlterarData(DateTime? data)
    {
        Data = data ?? DateTime.UtcNow;
    }

    public void DefinirUsuarioId(int usuarioId)
    {
        if (usuarioId <= 0)
            throw new DomainException("Não foi encontrado usuário para essa movimentação.");
        UsuarioId = usuarioId;
    }

    private void AlterarCategoria(Categoria categoria)
    {
        if (!CategoriaPolicy.CategoriaEhCompativel(categoria, Tipo))
            throw new DomainException("Categoria incompatível com o tipo da movimentação.");

        Categoria = categoria;
    }

    public void AlterarTipo(TipoMovimentacao tipo)
    {
        if (!CategoriaPolicy.CategoriaEhCompativel(Categoria, tipo))
            throw new DomainException("Tipo incompatível com a categoria.");

        Tipo = tipo;
    }
}
