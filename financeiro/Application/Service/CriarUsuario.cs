using financeiro.Application.Contract;
using financeiro.Domain.Repository;
using financeiro.Domain.Request;
using Financeiro.Domain.Entities;

namespace financeiro.Domain.Service; 

public class CriarUsuario : ICriarUsuario
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IHashService _hashService;

    public CriarUsuario(
        IUsuarioRepository usuarioRepository,
        IHashService hashService)
    {
        _usuarioRepository = usuarioRepository;
        _hashService = hashService;
    }

    public async Task CriarUsuarioAsync(CriarUsuarioRequest request)
    {
        var emailJaExiste = await _usuarioRepository.EmailJaExiste(request.Email);

        if (emailJaExiste)
            throw new Exception("E-mail já cadastrado.");

        var senha = _hashService.GerarHash(request.Senha);

        var usuario = new Usuario(
                request.Nome,
                request.Email,
                senha
            );

        await _usuarioRepository.CriarUsuario(usuario);
    }
}
