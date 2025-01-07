using Microsoft.AspNetCore.Mvc;
using TransporteChecklistAPI.Application.Interfaces;
using TransporteChecklistAPI.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarUsuarios()
    {
        var usuarios = await _usuarioService.ListarUsuariosAsync();
        return Ok(usuarios);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarUsuario([FromBody] UsuarioEntity usuario)
    {
        await _usuarioService.AdicionarUsuarioAsync(usuario);
        return CreatedAtAction(nameof(ObterUsuario), new { id = usuario.Id }, usuario);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterUsuario(int id)
    {
        var usuario = await _usuarioService.ObterUsuarioPorIdAsync(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }
}
