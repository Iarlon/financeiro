namespace financeiro.Domain.Request;

public class CriarUsuarioRequest
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
}
