using financeiro.Domain.Common;
using Financeiro.Domain.Entities;
using Financeiro.Domain.Enums;

namespace financeiro.Domain.Events;

public class MovimentacaoReclassificadaEvent : IDomainEvent
{
    public long MovimentacaoId { get; }
    public int UsuarioId { get; }
    public CategoriaEnum CategoriaAntiga { get; }
    public CategoriaEnum CategoriaNova { get; }
    public DateTime OccurredOn { get; }

    public MovimentacaoReclassificadaEvent(
        long movimentacaoId,
        int usuarioId,
        CategoriaEnum categoriaAntiga,
        CategoriaEnum categoriaNova)
    {
        MovimentacaoId = movimentacaoId;
        UsuarioId = usuarioId;
        CategoriaAntiga = categoriaAntiga;
        CategoriaNova = categoriaNova;
        OccurredOn = DateTime.UtcNow;
    }
}
