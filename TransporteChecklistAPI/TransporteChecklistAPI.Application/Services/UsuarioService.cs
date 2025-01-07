using TransporteChecklistAPI.Application.DTOs;
using TransporteChecklistAPI.Application.Interfaces;
using TransporteChecklistAPI.Domain.Entities;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    //public async Task<IEnumerable<UsuarioEntity>> ListarUsuariosAsync()
    //{
    //    return await _usuarioRepository.ListarTodosAsync();
    //}
    public async Task<IEnumerable<UsuarioDto>> ListarUsuariosAsync()
    {
        var usuarios = await _usuarioRepository.ListarTodosAsync();
        return usuarios.Select(u => new UsuarioDto
        {
            Id = u.Id,
            Nome = u.Nome,
            Tipo = u.Tipo
        });
    }

    public async Task<UsuarioEntity?> ObterUsuarioPorIdAsync(int id)
    {
        return await _usuarioRepository.ObterPorIdAsync(id);
    }

    public async Task AdicionarUsuarioAsync(UsuarioEntity usuario)
    {
        await _usuarioRepository.AdicionarAsync(usuario);
    }
}
