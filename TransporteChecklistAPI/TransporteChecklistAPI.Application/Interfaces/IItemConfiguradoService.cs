using TransporteChecklistAPI.Application.Common;
using TransporteChecklistAPI.Application.DTOs;
using TransporteChecklistAPI.Domain.Entities;

namespace TransporteChecklistAPI.Application.Interfaces;

public interface IItemConfiguradoService
{
    Task<IEnumerable<ItemConfiguradoDto>> ListarItensAsync();
    Task<ItemConfiguradoEntity?> ObterItemPorIdAsync(int id);
    Task<Resultado> AdicionarItemAsync(AtualizarItemConfiguradoCommand item);
}