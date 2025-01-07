using TransporteChecklistAPI.Domain.Entities;

namespace TransporteChecklistAPI.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<IEnumerable<UsuarioEntity>> ListarTodosAsync();
    Task<UsuarioEntity?> ObterPorIdAsync(int id);
    Task AdicionarAsync(UsuarioEntity usuario);
}