namespace financeiro.Infraestructure.Service;

using BCrypt.Net;
using financeiro.Application.Contract;

public class BcryptHashService : IHashService
{
    private const int WorkFactor = 12;

    public string GerarHash(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
            throw new ArgumentException("Senha inválida");

        return BCrypt.HashPassword(senha, WorkFactor);
    }

    public bool VerificarHash(string senhaDigitada, string senhaHash)
    {
        return BCrypt.Verify(senhaDigitada, senhaHash);
    }
}
