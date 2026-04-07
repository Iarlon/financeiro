namespace financeiro.Tests.Application;

using Moq;
using Xunit;
using financeiro.Domain.Service;
using financeiro.Domain.Repository;
using financeiro.Application.Contract;
using financeiro.Infraestructure;
using financeiro.Domain.Request;

public class UsuarioServiceTest
{
    private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
    private readonly Mock<IHashService> _hashServiceMock;
    private readonly CriarUsuario _service;

    public UsuarioServiceTest()
    {
        _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        _hashServiceMock = new Mock<IHashService>();
        _service = new CriarUsuario(_usuarioRepositoryMock.Object, _hashServiceMock.Object);
    }

    [Fact]
    public async Task CriarUsuario_EmailJaExiste_DeveLancarException()
    {
        var request = new CriarUsuarioRequest
        {
            Nome = "Iarlon",
            Email = "ialon@email.com",
            Senha = "123456"
        };

        _usuarioRepositoryMock
            .Setup(x => x.EmailJaExiste(request.Email))
            .ReturnsAsync(true);

        var exception = await Assert.ThrowsAsync<Exception>(() =>
            _service.CriarUsuarioAsync(request)
        );

        Assert.Equal("E-mail já cadastrado.", exception.Message);
    }

}
