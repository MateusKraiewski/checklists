using TransporteChecklistAPI.Application.Commands;
using TransporteChecklistAPI.Application.Common;
using TransporteChecklistAPI.Domain.Entities;

namespace TransporteChecklistAPI.Application.Interfaces
{
    public interface IChecklistService
    {
        Task<Resultado> IniciarChecklistAsync(IniciarChecklistCommand command);
        Task<Resultado> FinalizarChecklistAsync(int checklistId);
        Task<Resultado> AprovarChecklistAsync(int checklistId, bool aprovado);
        Task<IEnumerable<ChecklistEntity>> ListarChecklistsAsync();
        Task<ChecklistEntity?> ObterChecklistAsync(int checklistId);

    }
}
