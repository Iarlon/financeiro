using financeiro.Domain.Request;

namespace financeiro.Application.Contract;

public interface ICriarUsuario
{
    Task CriarUsuarioAsync(CriarUsuarioRequest request);
}
