namespace financeiro.Application.Contract
{
    public interface IHashService
    {
        string GerarHash(string senha);
        bool VerificarHash(string senhaDigitada, string senhaHash);
    }
}
