using Financeiro.Domain.Entities;
using Financeiro.Domain.Exceptions;
using Xunit;

namespace financeiro.Tests.Domain;

public class UsuarioTest
{
    [Fact]
    public void CriarUsuario_Valido_DeveCriar()
    {
        
        string nome = "Iarlon";
        string email = "ialon@email.com";
        string senha = "123456";

        
        var usuario = new Usuario(nome, email, senha);

        
        Assert.Equal(nome, usuario.Nome);
        Assert.Equal(email, usuario.Email);
        Assert.Equal(senha, usuario.Senha);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void AlterarNome_Invalido_DeveLancarException(string? nomeInvalido)
    {
        
        var usuario = new Usuario("Iarlon", "ialon@email.com", "123456");

       
        var exception = Assert.Throws<DomainException>(() => usuario.AlterarNome(nomeInvalido));
        Assert.Equal("O nome não pode ser vazio.", exception.Message);
    }

    [Fact]
    public void AlterarNome_Valido_DeveAlterar()
    {
        var usuario = new Usuario("Iarlon", "ialon@email.com", "123456");

        usuario.AlterarNome("Novo Nome");

        Assert.Equal("Novo Nome", usuario.Nome);
    }

    [Fact]
    public void AlterarEmail_Valido_DeveAlterar()
    {
        var usuario = new Usuario("Iarlon", "ialon@email.com", "123456");

        usuario.AlterarEmail("novo@email.com");

        Assert.Equal("novo@email.com", usuario.Email);
    }

    [Fact]
    public void AlterarSenha_Valida_DeveAlterar()
    {
        var usuario = new Usuario("Iarlon", "ialon@email.com", "123456");

        usuario.AlterarSenha("novaSenha");

        Assert.Equal("novaSenha", usuario.Senha);
    }

}
