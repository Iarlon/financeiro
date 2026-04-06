using Financeiro.Domain.Entities;

namespace financeiro.Domain.Repository;

public interface IUsuarioRepository
{
    Task<bool> EmailJaExiste(string email);
    Task CriarUsuario(Usuario usuario);

    Task AtualizarUsuario(Usuario usuario);
    Task<Usuario> ObterUsuarioPorId(int id);
}
