using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteChecklistAPI.Domain.Entities;

namespace TransporteChecklistAPI.Application.Interfaces;

public interface IChecklistRepository
{
    Task<ChecklistEntity?> ObterChecklistEmAndamentoAsync();
    Task AdicionarChecklistAsync(ChecklistEntity checklist);
    Task AtualizarChecklistAsync(ChecklistEntity checklist);
    Task<IEnumerable<ChecklistEntity>> ListarTodosAsync();
    Task<ChecklistEntity?> ObterPorIdAsync(int checklistId);
}
