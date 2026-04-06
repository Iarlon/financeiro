using financeiro.Application.Contract;
using financeiro.Domain.Request;
using Microsoft.AspNetCore.Mvc;

namespace financeiro.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ICriarUsuario _criarUsuarioService;
    public UsuarioController(ICriarUsuario criarUsuarioService)
    {
        _criarUsuarioService = criarUsuarioService;
    }

    [HttpPost]
    public async Task<IActionResult> CriarUsuarioAsync([FromBody] CriarUsuarioRequest request)
    {
        await _criarUsuarioService.CriarUsuarioAsync(request);
        return StatusCode(201, new { Mensagem = "Usuário criado com sucesso!" });
    }

}
