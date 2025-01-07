using TransporteChecklistAPI.Application.DTOs;
using TransporteChecklistAPI.Domain.Entities;

namespace TransporteChecklistAPI.Application.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDto>> ListarUsuariosAsync();
    Task<UsuarioEntity?> ObterUsuarioPorIdAsync(int id);
    Task AdicionarUsuarioAsync(UsuarioEntity usuario);
}
