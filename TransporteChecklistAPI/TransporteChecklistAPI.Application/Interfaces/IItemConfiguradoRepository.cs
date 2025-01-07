using TransporteChecklistAPI.Domain.Entities;

namespace TransporteChecklistAPI.Application.Interfaces;

public interface IItemConfiguradoRepository
{
    Task<IEnumerable<ItemConfiguradoEntity>> ListarTodosAsync();
    Task<ItemConfiguradoEntity?> ObterPorIdAsync(int id);
    Task AdicionarAsync(ItemConfiguradoEntity item);
}